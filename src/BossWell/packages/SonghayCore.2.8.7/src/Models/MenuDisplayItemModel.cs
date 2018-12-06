﻿using System.Linq;

namespace Songhay.Models
{
    /// <summary>
    /// Defines a colorable, selectable menu item
    /// </summary>
    public class MenuDisplayItemModel : ColorDisplayItemModel, ISelectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuDisplayItemModel"/> class.
        /// </summary>
        public MenuDisplayItemModel()
        {
            this.ChildItems = Enumerable.Empty<MenuDisplayItemModel>().ToArray();
        }

        /// <summary>
        /// Gets or sets the child items.
        /// </summary>
        /// <value>
        /// The child items.
        /// </value>
        public MenuDisplayItemModel[] ChildItems { get; set; }

        #region ISelectable members:

        /// <summary>
        /// Gets or sets whether this is default selection.
        /// </summary>
        /// <value>
        /// This is default selection.
        /// </value>
        public bool? IsDefaultSelection { get; set; }

        /// <summary>
        /// Gets or sets whether this is enabled.
        /// </summary>
        /// <value>
        /// This is enabled.
        /// </value>
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether this is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> when this is selected.
        /// </value>
        public bool? IsSelected { get; set; }

        #endregion
    }
}
