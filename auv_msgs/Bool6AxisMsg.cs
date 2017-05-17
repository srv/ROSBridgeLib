using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.auv_msgs;

/* 
 * @brief ROSBridgeLib
 * @author Francisco Bonin Font
 */

namespace ROSBridgeLib
{
    namespace auv_msgs {
        public class Bool6AxisMsg : ROSBridgeMsg
        {
            private bool _x;
            private bool _y;
            private bool _z;

            private bool _roll;
            private bool _pitch;
            private bool _yaw;

            public Bool6AxisMsg(JSONNode msg)
            { // parse ROS message elements into internal variables
                _x = bool.Parse(msg["x"]);
                _y = bool.Parse(msg["y"]);
                _z = bool.Parse(msg["z"]);
                _roll = bool.Parse(msg["roll"]);
                _pitch = bool.Parse(msg["pitch"]);
                _yaw = bool.Parse(msg["yaw"]);
            }

            public Bool6AxisMsg(bool x, bool y, bool z, bool roll, bool pitch, bool yaw)
            { // constructor to set the message values
                _x = x;
                _y = y;
                _z = z;
                _roll = roll;
                _pitch = pitch;
                _yaw = yaw;
            }

            public static string GetMessageType()
            {
                return "auv_msgs/Bool6Axis";
            }
            // functions to read values of entering messages
            public bool GetX()
            {
                return _x;
            }

            public bool GetY()
            {
                return _y;
            }

            public bool GetZ()
            {
                return _z;
            }

            public bool GetRoll()
            {
                return _x;
            }

            public bool GetPitch()
            {
                return _y;
            }

            public bool GetYaw()
            {
                return _z;
            }


            public override string ToString()
            {
                return "Bool6Axis [x=" + _x + ",  y=" + _y + ",  z=" + _z + ", roll = " + _roll +  ", pitch = " + _pitch + ", yaw =" + _yaw + "]";
            }

            public override string ToYAMLString()
            {
                return "{\"x\" : " + _x + ", \"y\" : " + _y + ", \"z\" : " + _z + ", \"roll\" : " + _roll + ", \"pitch\" = " + _pitch + ", \"yaw\" =" + _yaw + "}";
            }
        }
    }
}