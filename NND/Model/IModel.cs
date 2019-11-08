using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.Model {
    public interface IModel {
        /**<summary>
         * Returns list of Layer Types
         * </summary>*/
        LayerType[] GetLayerTypes();
        
    }
}
