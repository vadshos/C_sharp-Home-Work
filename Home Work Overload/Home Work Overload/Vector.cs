using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_Overload
{
    class Vector
    {

        private int _x, _y;
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
        public double Length
        {
            get => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
        public int X
        {
            get => _x;
            set =>_x = value; 
        }
        public int Y
        {
            get => _y;
            set => _y = value;
        }
        public override string ToString()
        {
            return $"Vector : ({X} , {Y})";
        }
        public static Vector operator +(Vector vF, Vector vS)
        {
            return new Vector((vF.X + vS.X), (vF.Y + vS.Y));
        }
        public static Vector operator ++(Vector v)
        {
            return new Vector((v.X +1), (v.Y+1));
        }
        public static Vector operator --(Vector v)
        {
            return new Vector((v.X-1), (v.Y-1));
        }
        public static bool operator true(Vector v)
        {
            return (v.X != 0 || v.Y != 0);
        }
        public static bool operator false(Vector v)
        {
            return (v.X == 0 && v.Y == 0);
        }
        public int this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return X;
                }else if( index == 1)
                {
                    return Y;
                }
                else
                {
                    throw new Exception("bad index ");
                }
            }
        }


        public static Vector operator -(Vector vF, Vector vS)
        {
            return new Vector((vF.X - vS.X), (vF.Y - vS.Y));
        }
        public static Tuple<int,int> operator *(Vector vF, int num)
        {
            return new Tuple<int,int>(vF.X * num,vF.Y * num);
        }
        public override bool Equals(object obj)
        {
            Vector v = obj as Vector;
            if(v == null)
            {
                return false;
            }
            return (this.X == v.X && this.Y == v.Y);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(Vector vF, Vector vS)
        {
            if (ReferenceEquals(vF, vS))
            {
                return true;
            }
            if(vF is null)
            {
                return false;
            }
            return vF.Equals(vS);
        }
        public static implicit operator Vector(int v)
        {
            return new Vector(v,0);
        }
        public static bool operator !=(Vector vF, Vector vS)
        {
            return !(vF == vS);
        }
    }
}
