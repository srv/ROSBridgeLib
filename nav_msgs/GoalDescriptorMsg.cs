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
    namespace nav_msgs
    {
        public class GoalDescriptorMsg : ROSBridgeMsg
        {
            private string _requester;
            private uint _id;
            private uint _priority;

            private const uint PRIORITY_LOW = 0;
            // uint PRIORITY_NORMAL = 10;
            private const uint PRIORITY_AVOID_OBSTACLE = 20;
            private const uint PRIORITY_EMERGENCY = 30;
            private const uint PRIORITY_MANUAL_OVERRIDE = 40;

            // PRIORITY DEFINITIONS
            private const uint PRIORITY_TELEOPERATION_LOW = 0;
            private const uint PRIORITY_SAFETY_LOW = 5;
            private const uint PRIORITY_NORMAL = 10;
            private const uint PRIORITY_NORMAL_HIGH = 20;
            private const uint PRIORITY_TELEOPERATION = 40;
            private const uint PRIORITY_SAFETY = 45;
            private const uint PRIORITY_SAFETY_HIGH = 50;
            private const uint PRIORITY_TELEOPERATION_HIGH = 60;


            public GoalDescriptorMsg(JSONNode msg)
            { // parse ROS message elements into internal variables
                _requester = msg["requester"];
                _id = uint.Parse(msg["id"]);
                _priority = uint.Parse(msg["priority"]);
            }

            public GoalDescriptorMsg(string requester, uint id, uint priority)
            { // constructor to set the message values
                _requester = requester;
                _id = id;
                _priority = priority;
            }

            public static string GetMessageType()
            {
                return "nav_msgs/GoalDescriptor";
            }
            // functions to read values of entering messages
            public string GetRequester()
            {
                return _requester;
            }

            public uint GetId()
            {
                return _id;
            }

            public uint GetPriority()
            {
                return _priority;
            }

            public override string ToString()
            {
                return "GoalDescriptor [requester=" + _requester + ",  id=" + _id + ",  priority=" + _priority +  "]";
            }

            public override string ToYAMLString()
            {
                return "{\"requester\" : " + _requester + ", \"id\" : " + _id + ", \"priority\" : " + _priority + "}";
            }
        }
    }
}