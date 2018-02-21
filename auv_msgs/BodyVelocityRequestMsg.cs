using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.std_msgs;
using ROSBridgeLib.geometry_msgs;
using UnityEngine;

/**
 * Define a Body Velocity Request message. This has been hand-crafted from the corresponding
 * message file.
 * @brief ARSEA Project
 * @author Francisco Bonin Font
 * @author System, Robotics and Vision
 * @author University of the Balearic Islands
 */

namespace ROSBridgeLib
{
    namespace auv_msgs
    {
        public class BodyVelocityRequestMsg : ROSBridgeMsg
        {
            private HeaderMsg _header;
            private GoalDescriptorMsg _goal;
            private TwistMsg _twist;
            private Bool6AxisMsg _disable_axis;
            
            public BodyVelocityRequestMsg(JSONNode msg)
            { 
                // parse message fields into class data
                _header = new HeaderMsg(msg["header"]);
                _goal = new GoalDescriptorMsg(msg["goal"]);
                _twist = new TwistMsg(msg["twist"]);
                _disable_axis = new Bool6AxisMsg(msg["disable_axis"]);
               
            }

            public BodyVelocityRequestMsg(HeaderMsg header,
                             GoalDescriptorMsg goal,
                             TwistMsg twist,
                             Bool6AxisMsg disable_axis
                             )
            {
                _header = header;
                _goal = goal;
                _twist = twist;
                _disable_axis = disable_axis;
            }

            public static string getMessageType()
            {
                return "auv_msgs/BodyVelocityReq";
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
                // return "auv_msgs/BodyVelocityReq  [header=" + _header.ToString() +
                //         ", goal=" + _goal.ToString() +
                //         ", twist=" + _twist.ToString() +
                //          ", disable_axis=" + _disable_axis.ToString() + "]";
                return "BodyVelocityReq  [header=" + _header.ToString() +
                         ", goal=" + _goal.ToString() +
                         ", twist=" + _twist.ToString() +
                          ", disable_axis=" + _disable_axis.ToString() + "]";
            }
            				//return "{\"linear\" : " + _linear.ToYAMLString() + ", \"angular\" : " + _angular.ToYAMLString() + "}";

            public override string ToYAMLString()
            {
                return "{\"header\" : " + _header.ToYAMLString() +
                        ", \"goal\" : " + _goal.ToYAMLString() +
                        ", \"twist\" : " + _twist.ToYAMLString() + "}";
                //", \"disable_axis\" : " + _disable_axis.ToYAMLString() + "}"; // fbf 21/09/2017 do not include the disable axis. These values ar automatically
                // informed to false in the ROS side, and including them breaks the message JSON message coherency generating an error in the server side 

            }
        }
    }
}
