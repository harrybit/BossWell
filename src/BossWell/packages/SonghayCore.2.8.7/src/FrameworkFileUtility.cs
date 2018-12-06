﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Songhay
{
    /// <summary>
    /// A few static helper members
    /// for <see cref="System.IO"/>.
    /// </summary>
    public static partial class FrameworkFileUtility
    {
        static FrameworkFileUtility()
        {
            parentDirectoryCharsPattern = string.Format(@"\.\.\{0}", Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Counts the parent directory chars.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method is useful when running <see cref="GetParentDirectory(string, int)"/>.
        /// </remarks>
        public static int CountParentDirectoryChars(string path)
        {
            if (string.IsNullOrEmpty(path)) return default(int);
            var matches = Regex.Matches(path, parentDirectoryCharsPattern);
            return matches.Count;
        }

        /// <summary>
        /// Finds the parent directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="parentName">Name of the parent.</param>
        /// <param name="levels">The levels.</param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException">The expected directory is not here.</exception>
        public static string FindParentDirectory(string path, string parentName, int levels)
        {
            return FindParentDirectoryInfo(path, parentName, levels)?.FullName;
        }

        /// <summary>
        /// Finds the parent <see cref="DirectoryInfo"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="parentName">Name of the parent.</param>
        /// <param name="levels">The levels.</param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException">The expected directory is not here.</exception>
        public static DirectoryInfo FindParentDirectoryInfo(string path, string parentName, int levels)
        {
            if (string.IsNullOrEmpty(path)) throw new DirectoryNotFoundException("The expected directory is not here.");

            var info = new DirectoryInfo(path);

            var isParent = (info.Name == parentName);
            var hasNullParent = (info.Parent == null);
            var hasTargetParent = (info.Parent.Name == parentName);

            if (!info.Exists) return null;
            if (isParent) return info;
            if (hasNullParent) return null;
            if (hasTargetParent) return info.Parent;

            levels = Math.Abs(levels);
            --levels;

            var hasNoMoreLevels = (levels == 0);

            if (hasNoMoreLevels) return null;

            return FindParentDirectoryInfo(info.Parent.FullName, parentName, levels);
        }

        /// <summary>
        /// Gets the parent directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="levels">The levels.</param>
        /// <returns></returns>
        /// <remarks>
        /// A recursive wrapper for <see cref="Directory.GetParent(string)"/>.
        /// </remarks>
        public static string GetParentDirectory(string path, int levels)
        {
            if (string.IsNullOrEmpty(path)) return path;

            levels = Math.Abs(levels);
            if (levels == 0) return path;

            var info = Directory.GetParent(path);
            if (info == null) return path;
            path = info.FullName;

            --levels;
            if (levels >= 1) return GetParentDirectory(path, levels);
            return path;
        }

        /// <summary>
        /// Gets the parent <see cref="DirectoryInfo"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="levels">The levels.</param>
        /// <returns></returns>
        /// <remarks>
        /// A recursive wrapper for <see cref="Directory.GetParent(string)"/>.
        /// </remarks>
        public static DirectoryInfo GetParentDirectoryInfo(string path, int levels)
        {
            if (string.IsNullOrEmpty(path)) return null;

            var info = new DirectoryInfo(path);

            levels = Math.Abs(levels);
            if (levels == 0) return info;

            if (info.Parent == null) return info;
            path = info.FullName;

            --levels;
            return (levels >= 1) ? GetParentDirectoryInfo(path, levels) : info;
        }

        /// <summary>
        /// Trims the leading directory separator chars.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <remarks>
        /// Trims leading <see cref="Path.AltDirectorySeparatorChar"/> and/or <see cref="Path.DirectorySeparatorChar"/>,
        /// formatting relative paths for <see cref="Path.Combine(string, string)"/>.
        /// </remarks>
        public static string TrimLeadingDirectorySeparatorChars(string path)
        {
            if (string.IsNullOrEmpty(path)) return path;
            return path.TrimStart(new[] { Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar });
        }

        /// <summary>
        /// Trims the parent directory chars.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string TrimParentDirectoryChars(string path)
        {
            if (string.IsNullOrEmpty(path)) return path;

            return Regex.Replace(path, parentDirectoryCharsPattern, string.Empty);
        }

        static readonly string parentDirectoryCharsPattern;
    }
}
