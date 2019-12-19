namespace NND.Model
{
    public interface IModel
    {
        /**<summary>
         * Returns list of Layer Types
         * </summary>*/
        LayerType[] GetLayerTypes();
        LayerNode[] GetLayerNodes();

        void AddNode(LayerType baseType);
        void AddNode(LayerType baseType, int position);
        void RemoveNode(int position);
        void MoveNode(int src, int dest);
    }
}