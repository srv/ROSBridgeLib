using SimpleJSON;
using ROSBridgeLib.std_msgs;
using UnityEngine;
using PointCloud;

/**
 * Define a PointCloud2 message.
 *  
 * @author Miquel Massot Campos
 */

namespace ROSBridgeLib {
	namespace sensor_msgs {
		public class PointCloud2Msg : ROSBridgeMsg {
			private HeaderMsg _header;
			private uint _height;
			private uint _width;
			private PointFieldMsg[] _fields;
			private bool _is_bigendian;
			private bool _is_dense;
			private uint _point_step;
			private uint _row_step;
			private byte[] _data;
            private Vector3[] _points;
            private Color[] _colors;
            //private PointCloud<PointXYZRGB> _cloud;

            public PointCloud2Msg(JSONNode msg) {
				_header = new HeaderMsg (msg ["header"]);
				_height = uint.Parse(msg ["height"]);
				_width = uint.Parse(msg ["width"]);
                _points = new Vector3[_width * _height];
                _colors = new Color[_width * _height];
                _is_bigendian = msg["is_bigendian"].AsBool;
				_is_dense = msg["is_dense"].AsBool;
				_point_step = uint.Parse(msg ["point_step"]);
				_row_step = uint.Parse(msg ["row_step"]);
                _fields = new PointFieldMsg[msg["fields"].Count];
                for (int i = 0; i < _fields.Length; i++)
                {
                    _fields[i] = new PointFieldMsg(msg["fields"][i]);
                }
                _data = System.Convert.FromBase64String(msg["data"]);
                //_cloud = ReadData(_data);
                ReadData(_data);
            }

			public PointCloud2Msg(HeaderMsg header, uint height, uint width, PointFieldMsg fields, bool is_bigendian, uint point_step, uint row_step, byte[] data, bool is_dense) {
				_header = header;
				_height = height;
				_width = width;
				//_fields = fields;
				_is_dense = is_dense;
				_is_bigendian = is_bigendian;
				_point_step = point_step;
				_row_step = row_step;
                //_cloud = ReadData(data);
                ReadData(_data);
            }

			private PointCloud<PointXYZRGB> ReadData(byte[] byteArray) {
				PointCloud<PointXYZRGB> cloud = new PointCloud<PointXYZRGB> ();
                for (int i = 0; i < _width * _height; i++) {
                    float x = System.BitConverter.ToSingle(_data, i * (int)_point_step + 0);
                    float y = System.BitConverter.ToSingle(_data, i * (int)_point_step + 4);
                    float z = System.BitConverter.ToSingle(_data, i * (int)_point_step + 8);
                    if (!float.IsNaN(x + y + z))
                    {
                        //PointXYZRGB p = new PointXYZRGB(x, y, z, rgb);
                        //cloud.Add(p);
                        _points[i] = new Vector3(-x, -z, y);
                        byte r = _data[i * (int)_point_step + 16 + 2];
                        byte g = _data[i * (int)_point_step + 16 + 1];
                        byte b = _data[i * (int)_point_step + 16];
                        _colors[i] = new Color((float)r / 255.0f, (float)g / 255.0f, (float)b / 255.0f);
                    }   
				}
                return cloud;
			}

            public HeaderMsg GetHeader()
            {
                return _header;
            }

			public uint GetWidth() {
				return _width;
			}

			public uint GetHeight() {
				return _height;
			}

			public uint GetPointStep() {
				return _point_step;
			}

			public uint GetRowStep() {
				return _row_step;
			}

            //public PointCloud<PointXYZRGB> GetCloud() {
            //	return _cloud;
            //}

            public Vector3[] GetPoints()
            {
                return _points;
            }

            public Color[] GetColors()
            {
                return _colors;
            }

            public static string GetMessageType() {
				return "sensor_msgs/PointCloud2";
			}

			public override string ToString() {
				return "PointCloud2 [header=" + _header.ToString() +
						"height=" + _height +
						"width=" + _width +
						//"fields=" + _fields.ToString() +
						"is_bigendian=" + _is_bigendian +
						"is_dense=" + _is_dense +
						"point_step=" + _point_step +
						"row_step=" + _row_step + "]";
			}

			public override string ToYAMLString() {
				return "{\"header\" :" + _header.ToYAMLString() +
						"\"height\" :" + _height +
						"\"width\" :" + _width +
						//"\"fields\" :" + _fields.ToYAMLString() +
						"\"is_bigendian\" :" + _is_bigendian +
						"\"is_dense\" :" + _is_dense +
						"\"point_step\" :" + _point_step +
						"\"row_step\" :" + _row_step + "}";
			}
		}
	}
}
