using ImageProcessingLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingLib
{
    public abstract class ImageBase : IEquatable<ImageBase>
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public int Size { get { return Width * Height; } }
        public int[] Data { get; protected set; }
        public int DataLength { get { return Data.Length; } }

        public void InitializeNew(int width, int height)
        {
            var data = new int[width * height];
            InitializeNew(data, width, height);
        }

        public void InitializeNew(int[] data, int width, int height)
        {
            if (data.Length != width * height)
                throw new ArgumentException("Invalid data size");
            SetSizes(width, height);
            Data = data;
        }

        public void InitializeFrom(ImageBase img)
        {
            InitializeNew(img.Width, img.Height);
            img.Data.CopyTo(Data, 0);
        }

        protected void SetSizes(int width, int height)
        {
            Width = width;
            Height = height;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected int GetIndex(int x, int y)
        {
            return x + y * Width;
        }

        public int GetData(int i)
        {
            return Data[i];
        }

        public int GetData(int x, int y)
        {
            var index = GetIndex(x, y);
            return Data[index];
        }

        public void SetData(int i, int data)
        {
            Data[i] = data;
        }

        public void SetData(int x, int y, int data)
        {
            var index = GetIndex(x, y);
            Data[index] = data;
        }

        public void Swap(int sourceX, int sourceY, int destinationX, int destinationY)
        {
            int sourceIndex = sourceX + sourceY * Width;
            int destinationIndex = destinationX + destinationY * Width;
            var temp = Data[sourceIndex];
            Data[sourceIndex] = Data[destinationIndex];
            Data[destinationIndex] = temp;
        }

        public int ClampWidth(int value)
        {
            return MathUtils.Clamp(value, 0, Width - 1);
        }

        public int ClampHeight(int value)
        {
            return MathUtils.Clamp(value, 0, Height - 1);
        }

        public bool ExceedsWidth(int value)
        {
            return value < 0 || value >= Width;
        }

        public bool ExceedsHeight(int value)
        {
            return value < 0 || value >= Height;
        }

        public void GetCenter(out int x, out int y)
        {
            x = Width / 2;
            y = Height / 2;
        }

        public bool Equals(ImageBase other)
        {
            if (other.Width != Width || other.Height != Height)
                return false;
            return Enumerable.SequenceEqual(other.Data, Data);
        }

        public override bool Equals(object obj)
        {
            var img = obj as ImageBase;
            if (obj == null)
                return false;
            return Equals(img);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            int len = Data.Length;
            for (int i = 0; i < len; i++)
                hash ^= Data[i].GetHashCode();
            return hash;
        }
    }
}
