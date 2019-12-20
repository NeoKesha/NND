using JetBrains.Annotations;

namespace NND.Model
{
    public interface IModel
    {
        /**<summary>
         * Returns list of Layer Types
         * </summary>*/
        LayerType[] GetLayerTypes();
        LayerNode[] GetLayerNodes();

        void AddNode([NotNull] LayerType baseType);
        void AddNode([NotNull] LayerType baseType, int position);
        void RemoveNode(int position);
        void MoveNode(int src, int dest);

        string GetDType();
        string GetBSize();
    }
}