using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.std_msgs;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.geographic_msgs;
using UnityEngine;

/**
 * Define a auv_msgs Body Velocity Request message. This has been hand-crafted from the corresponding
 * message file.
 * @brief ARSEA Project
 * @author Francisco Bonin Font
 * @author System, Robotics and Vision
 * @author University of the Balearic Islands
 */

namespace ROSBridgeLib
{
    namespace nav_msgs
    {
        public class BodyVelocityRequestMsg : ROSBridgeMsg
        {
            public HeaderMsg _header;
            public GoalDescriptorMsg _goal;
            public TwistMsg _twist;
            public auv_msgs.Bool6AxisMsg _disable_axis;
            
            public BodyVelocityRequestMsg(JSONNode msg)
            { 
                // parse message fields into class data
                _header = new HeaderMsg(msg["header"]);
                _goal = new GoalDescriptorMsg(msg["goal"]);
                _twist = new TwistMsg(msg["twist"]);
                _disable_axis = new auv_msgs.Bool6AxisMsg(msg["disable_axis"]);
                

                //Debug.Log("NavStsMsg done and it looks like " + this.ToString());
            }

            public BodyVelocityRequestMsg(HeaderMsg header,
                             GoalDescriptorMsg goal,
                             TwistMsg twist,
                             auv_msgs.Bool6AxisMsg disable_axis
                             )
            {
                _header = header;
                _goal = goal;
                _twist = twist;
                _disable_axis = disable_axis;
            }

            public static string getMessageType()
            {
                return "auv_msgs/NavSts ";
            }

            public HeaderMsg GetHeader()
            {
                return _header;
            }

            public GoalDescriptorMsg GetGoal()
            {
                return _goal;
            }

            public TwistMsg GetTwist()
            {
                return _twist;
            }

            public auv_msgs.Bool6AxisMsg GetDisableAxis()
            {
                return _disable_axis;
            }

            public override string ToString()
            {
                return "auv_msgs/NavSts  [header=" + _header.ToString() +
                        ", goal=" + _goal.ToString() +
                        ", twist=" + _twist.ToString() +
                        ", disable_axis=" + _disable_axis.ToString() + "]";
            }

            public override string ToYAMLString()
            {
                return "{\"header\":" + _header.ToYAMLString() +
                        ", \"goal\":" + _goal.ToYAMLString() +
                        ", \"twist\":" + _twist.ToYAMLString() +
                        ", \"disable_axis\":" + _disable_axis.ToYAMLString() + "}";
            }
        }
    }
}
