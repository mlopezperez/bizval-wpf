using BizVal.Model;

namespace BizVal
{
    public interface IHierarchyManager
    {
        Hierarchy GetCurrentHierarchy();

        void SaveHierarchy(Hierarchy modifiedHierarchy);
    }
}
