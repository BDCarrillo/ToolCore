﻿// <copyright file="Ray.cs">
//     Distributed under the BSD Licence (see LICENCE file).
//     
//     Copyright (c) 2014, Nition, http://www.momentstudio.co.nz/
//     Copyright (c) 2017, Máté Cserép, http://codenet.hu
//     All rights reserved.
// </copyright>
namespace Octree
{
    using System;
    using VRageMath;
    using ProtoBuf;

    /// <summary>
    /// Representation of rays.
    /// </summary>
    /// <remarks>
    /// A ray is an infinite line starting at <see cref="Origin"/> and going in some <see cref="Direction"/>.
    /// 
    /// This class was inspired by the Ray type of the Unity Engine and 
    /// designed with the exact same interface to provide maximum compatibility.
    /// </remarks>
    [ProtoContract]
    public struct Ray
    {
        /// <summary>
        /// Gets or sets the origin of the ray.
        /// </summary>
        [ProtoMember(1)]
        public Vector3 Origin { get; set; }

        /// <summary>
        /// The direction of the ray.
        /// </summary>
        [ProtoMember(2)]
        private Vector3 _direction;
        /// <summary>
        /// Gets or sets the direction of the ray.
        /// </summary>
        public Vector3 Direction
        {
            get { return _direction; }
            set { _direction = Vector3.Normalize(value); }
        }

        /// <summary>
        /// Creates a ray starting at origin along direction.
        /// </summary>
        /// <param name="origin">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            _direction = Vector3.Normalize(direction);
        }

        /// <summary>
        /// Returns a point at the given distance along the ray.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <returns>The point on the ray.</returns>
        public Vector3 GetPoint(float distance)
        {
            return Origin + Direction * distance;
        }

        /// <summary>
        /// Returns a nicely formatted string for this ray.
        /// </summary>
        public override string ToString()
        {
            return String.Format("Origin: {0}, Dir: {1}",
                Origin,
                Direction
            );
        }

        /// <summary>
        /// Returns a nicely formatted string for this ray.
        /// </summary>
        /// <param name="format">The format for the origin and direction.</param>
        public string ToString(string format)
        {
            return String.Format("Origin: {0}, Dir: {1}",
                Origin.ToString(format),
                Direction.ToString(format)
            );
        }
    }
}