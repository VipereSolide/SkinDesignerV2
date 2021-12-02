using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FeatherTools.PRO.Serialization
{
    public static class SaveSystem
    {

        #region Binary

        ///<summary>Save object data (as classes, struct or even string, int and floats) in a binary file.</summary>
        ///<param name="savedData">The saved object data in the file.</param>
        ///<param name="savedFilePath">Where (folder name + path) the file will be saved.</param>
        public static void BinarySave(object savedData, string savedFilePath)
        {
            Serialize(savedData, savedFilePath);
        }

        ///<summary>Load and deserialize a binary file to get it's content<.</summary>
        ///<param name="savedFilePath">Where the file is located.</param>
        public static object BinaryLoad(string savedFilePath)
        {
            object deserializedProduct = Deserialize(savedFilePath);

            if(deserializedProduct == null)
            {
                Debug.LogError("Deserialization did not return anything. You may have misswritten the filePath.");
                return null;
            }
            else
            {
                return deserializedProduct;
            }
        }

        #endregion

        #region JSONSerializing

        /// <summary>Serialize an object to a JSON file.</summary>
        /// <param name="serializedData">The obejct to be serialized.</param>
        /// <param name="path">Where the file will be located.</param>
        public static void SerializeToJSON(object serializedData, string path)
        {
            string jsonData = JsonUtility.ToJson(serializedData);
            byte[] jsonDataInBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            
            File.WriteAllBytes(path, Kabata.Compress(jsonDataInBytes));
        }

        /// <summary>Deserialize an json file into a string.</summary>
        /// <param name="path">Where the file will is located.</param>
        public static string DeserializeFromJSON(string path)
        {
            string jsonData = JsonUtility.FromJson<string>(path);
            byte[] jsonDataInBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
            byte[] uncompressedData = Kabata.Decompress(jsonDataInBytes);
            string uncompressedDataInString = System.Text.Encoding.UTF8.GetString(uncompressedData, 0, uncompressedData.Length);

            return uncompressedDataInString;

        }

        #endregion

        #region PlayerPrefs

        ///<summary>Allows to save Vector3 in memory using PlayerPrefs, which is impossible with Unity default system.</summary>
        ///<param name="savedVector3">The vector3 you want to save in memory.</summary>
        ///<param name="memoryName">The name of the Vector3 you give to be able to get it back in the future.</summary>
        public static void SaveVector3InMemory(Vector3 savedVector3, string memoryName)
        {
            PlayerPrefs.SetFloat(memoryName + "_vX", savedVector3.x);
            PlayerPrefs.SetFloat(memoryName + "_vY", savedVector3.y);
            PlayerPrefs.SetFloat(memoryName + "_vZ", savedVector3.z);
        }

        ///<summary>Allows to get a Vector3 saved before in PlayerPrefs using SaveVector3InMemory.</summary>
        ///<param name="memoryName">The name you gave to your Vector3.</summary>
        public static Vector3 GetVector3InMemory(string memoryName)
        {
            float xValue = PlayerPrefs.GetFloat(memoryName + "_X");
            float yValue = PlayerPrefs.GetFloat(memoryName + "_Y");
            float zValue = PlayerPrefs.GetFloat(memoryName + "_Z");

            return new Vector3(xValue, yValue, zValue);
        }

        ///<summary>Allows to save Vector2 in memory using PlayerPrefs, which is impossible with Unity default system.</summary>
        ///<param name="savedVector2">The vector2 you want to save in memory.</summary>
        ///<param name="memoryName">The name of the Vector2 you give to be able to get it back in the future.</summary>
        public static void SaveVector2InMemory(Vector2 savedVector2, string memoryName)
        {
            PlayerPrefs.SetFloat(memoryName + "_vX", savedVector2.x);
            PlayerPrefs.SetFloat(memoryName + "_vY", savedVector2.y);
        }

        ///<summary>Allows to get a Vector2 saved before in PlayerPrefs using SaveVector2InMemory.</summary>
        ///<param name="memoryName">The name you gave to your Vector2.</summary>
        public static Vector2 GetVector2InMemory(string memoryName)
        {
            float xValue = PlayerPrefs.GetFloat(memoryName + "_X");
            float yValue = PlayerPrefs.GetFloat(memoryName + "_Y");

            return new Vector2(xValue, yValue);
        }


        ///<summary>Allows to save Vector3Int in memory using PlayerPrefs, which is impossible with Unity default system.</summary>
        ///<param name="savedVector3">The Vector3Int you want to save in memory.</summary>
        ///<param name="memoryName">The name of the Vector3Int you give to be able to get it back in the future.</summary>
        public static void SaveVector3IntInMemory(Vector3Int savedVector3Int, string memoryName)
        {
            PlayerPrefs.SetInt(memoryName + "_vX", savedVector3Int.x);
            PlayerPrefs.SetInt(memoryName + "_vY", savedVector3Int.y);
            PlayerPrefs.SetInt(memoryName + "_vZ", savedVector3Int.z);
        }

        ///<summary>Allows to get a Vector3Int saved before in PlayerPrefs using SaveVector3IntInMemory.</summary>
        ///<param name="memoryName">The name you gave to your Vector3Int.</summary>
        public static Vector3Int GetVector3IntInMemory(string memoryName)
        {
            int xValue = PlayerPrefs.GetInt(memoryName + "_X");
            int yValue = PlayerPrefs.GetInt(memoryName + "_Y");
            int zValue = PlayerPrefs.GetInt(memoryName + "_Z");

            return new Vector3Int(xValue, yValue, zValue);
        }

        ///<summary>Allows to save Vector2 in memory using PlayerPrefs, which is impossible with Unity default system.</summary>
        ///<param name="savedVector2Int">The vector2 you want to save in memory.</summary>
        ///<param name="memoryName">The name of the Vector2 you give to be able to get it back in the future.</summary>
        public static void SaveVector2IntInMemory(Vector2Int savedVector2Int, string memoryName)
        {
            PlayerPrefs.SetInt(memoryName + "_vX", savedVector2Int.x);
            PlayerPrefs.SetInt(memoryName + "_vY", savedVector2Int.y);
        }

        ///<summary>Allows to get a Vector2 saved before in PlayerPrefs using SaveVector2InMemory.</summary>
        ///<param name="memoryName">The name you gave to your Vector2.</summary>
        public static Vector2Int GetVector2IntInMemory(string memoryName)
        {
            int xValue = PlayerPrefs.GetInt(memoryName + "_X");
            int yValue = PlayerPrefs.GetInt(memoryName + "_Y");

            return new Vector2Int(xValue, yValue);
        }

        #endregion

        #region Converters

        /// <summary>Convert a SerializableVector3 into a Vector3.</summary>
        /// <param name="vector">The SerializableVector3 you want to convert.</param>
        public static Vector3 SerializableVector3ToVector3(SerializableVector3 vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }

        /// <summary>Convert a SerializableVector3Int into a Vector3Int.</summary>
        /// <param name="vector">The SerializableVector3Int you want to convert.</param>
        public static Vector3Int SerializableVector3IntToVector3Int(SerializableVector3Int vector)
        {
            return new Vector3Int(vector.x, vector.y, vector.z);
        }

        /// <summary>Convert a SerializableVector2 into a Vector2.</summary>
        /// <param name="vector">The SerializableVector2 you want to convert.</param>
        public static Vector2 SerializableVector2ToVector2(SerializableVector2 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        /// <summary>Convert a SerializableVector2Int into a Vector2Int.</summary>
        /// <param name="vector">The SerializableVector2Int you want to convert.</param>
        public static Vector2Int SerializableVector2IntToVector2Int(SerializableVector2Int vector)
        {
            return new Vector2Int(vector.x, vector.y);
        }

        #endregion

        #region Utility

        private static void Serialize(object toSave, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(new BufferedStream(stream), toSave);
            stream.Close();
        }

        private static object Deserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            return (object)formatter.Deserialize(new BufferedStream(stream));
        }

        //Great thanks to Bellzebu for these lines of code!
        private static async Task<byte[]> Decompress(byte[] inputBytes)
        {
            using (MemoryStream newInStream = new MemoryStream(inputBytes))
            {
                SevenZip.Compression.LZMA.Decoder decoder = new SevenZip.Compression.LZMA.Decoder();

                newInStream.Seek(0, 0);

                using (MemoryStream newOutStream = new MemoryStream())
                {
                    byte[] properties2 = new byte[5];

                    if (await newInStream.ReadAsync(properties2, 0, 5) != 5)
                    {
                        throw (new Exception("input .lzma is too short"));
                    }

                    long outSize = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        int v = newInStream.ReadByte();

                        if (v < 0) {
                            throw (new Exception("Can't Read 1"));
                        }

                        outSize |= ((long)(byte)v) << (8 * i);
                    }

                    decoder.SetDecoderProperties(properties2);
                    long compressedSize = newInStream.Length - newInStream.Position;
                    decoder.Code(newInStream, newOutStream, compressedSize, outSize, null);
                    return newOutStream.ToArray();
                }
            }
        }

        private static async Task<byte[]> DecompDeserializeMapsAsync(string filename)
        {
            byte[] buff;

            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                buff = new byte[file.Length];
                await file.ReadAsync(buff, 0, (int)file.Length);
            }

            if (buff == null && buff.Length == 0 )
            {
                throw new ArgumentNullException("Map data can not be empty");
            }

            // return Kabata.Decompress(buff);
            return await Decompress(buff);

        }

        #endregion
    
    }

    #region Interfaces
    #endregion

    #region CustomClasses

    [System.Serializable]
    public struct SerializableVector3
    {
        public float x;
        public float y;
        public float z;

        public SerializableVector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    [System.Serializable]
    public struct SerializableVector3Int
    {
        public int x;
        public int y;
        public int z;

        public SerializableVector3Int(int _x, int _y, int _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    [System.Serializable]
    public struct SerializableVector2
    {
        public float x;
        public float y;

        public SerializableVector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }

    [System.Serializable]
    public struct SerializableVector2Int
    {
        public int x;
        public int y;

        public SerializableVector2Int(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    #endregion

}