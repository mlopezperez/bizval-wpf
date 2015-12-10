using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace BizVal.App.Behaviors
{
    public class TextBoxInputBehavior : Behavior<TextBox>
    {
        const NumberStyles ValidNumberStyles = NumberStyles.AllowDecimalPoint |
                                                   NumberStyles.AllowThousands |
                                                   NumberStyles.AllowLeadingSign;
        public TextBoxInputBehavior()
        {
            this.InputMode = TextBoxInputMode.None;
            this.JustPositiveDecimalInput = false;
        }

        public TextBoxInputMode InputMode { get; set; }


        public static readonly DependencyProperty JustPositiveDecimalInputProperty =
         DependencyProperty.Register("JustPositiveDecimalInput", typeof(bool),
         typeof(TextBoxInputBehavior), new FrameworkPropertyMetadata(false));

        public bool JustPositiveDecimalInput
        {
            get { return (bool)this.GetValue(JustPositiveDecimalInputProperty); }
            set { this.SetValue(JustPositiveDecimalInputProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewTextInput += this.AssociatedObjectPreviewTextInput;
            this.AssociatedObject.PreviewKeyDown += this.AssociatedObjectPreviewKeyDown;

            DataObject.AddPastingHandler(this.AssociatedObject, this.Pasting);

        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewTextInput -= this.AssociatedObjectPreviewTextInput;
            this.AssociatedObject.PreviewKeyDown -= this.AssociatedObjectPreviewKeyDown;

            DataObject.RemovePastingHandler(this.AssociatedObject, this.Pasting);
        }

        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));

                if (!this.IsValidInput(this.GetText(pastedText)))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.CancelCommand();
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                e.CancelCommand();
            }
        }

        private void AssociatedObjectPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (!this.IsValidInput(this.GetText(" ")))
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                }
            }
        }

        private void AssociatedObjectPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!this.IsValidInput(this.GetText(e.Text)))
            {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private string GetText(string input)
        {
            var txt = this.AssociatedObject;
            var realtext = txt.Text.Remove(txt.SelectionStart, txt.SelectionLength);
            var newtext = realtext.Insert(txt.CaretIndex, input);

            return newtext;
        }

        private bool IsValidInput(string input)
        {
            switch (this.InputMode)
            {
                case TextBoxInputMode.None:
                    return true;
                case TextBoxInputMode.DigitInput:
                    return this.CheckIsDigit(input);

                case TextBoxInputMode.DecimalInput:
                    decimal d;
                    //wen mehr als ein Komma
                    if (input.ToCharArray().Where(x => x == ',').Count() > 1)
                        return false;

                    if (input.Contains("-"))
                    {
                        //minus einmal am anfang zulässig
                        if (!this.JustPositiveDecimalInput && input.IndexOf("-", StringComparison.Ordinal) == 0 && input.Length == 1)
                            return true;
                        else
                        {
                            var result = decimal.TryParse(input, ValidNumberStyles, CultureInfo.CurrentCulture, out d);
                            return result;
                        }
                    }
                    else
                    {
                        var result = decimal.TryParse(input, ValidNumberStyles, CultureInfo.CurrentCulture, out d);
                        return result;
                    }


                default: throw new ArgumentException("Unknown TextBoxInputMode");

            }
            return true;
        }

        private bool CheckIsDigit(string wert)
        {
            return wert.ToCharArray().All(Char.IsDigit);
        }
    }

    public enum TextBoxInputMode
    {
        None,
        DecimalInput,
        DigitInput
    }
}
