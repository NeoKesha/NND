using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void AddNode(LayerType baseType, Int32 position);
        void RemoveNode(Int32 position);
        void MoveNode(Int32 from, Int32 to);

    }
}
