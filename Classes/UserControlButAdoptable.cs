//  Bazaar Checker
//  Copyright (C) 2022 AlvaroBajceps(marcinwal9@gmail.com)
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//  Source: https://github.com/AlvaroBajceps/BazaarChecker

using System;
using System.Windows.Forms;

namespace BazaarChecker.Classes
{
    public class UserControlButAdoptable : UserControl
    {
        public enum CreationOptions
        {
            asUsual,
            resizeWithParent
        }

        WeakReference<Control> oldParentWR = new(null);
        [System.ComponentModel.Description("Occurs when this object gains new parent")]
        public event AdoptionHouseEventHandler GotAdopted;
        [System.ComponentModel.Description("Occurs when this object loses parent")]
        public event AdoptionHouseEventHandler GotOrphaned;

        CreationOptions options;
        public CreationOptions Options
        {
            get => options;
            set
            {
                if (oldParentWR.TryGetTarget(out var oldParent))
                {
                    if (options.HasFlag(CreationOptions.resizeWithParent) && !value.HasFlag(CreationOptions.resizeWithParent))
                    {
                        oldParent.Resize -= AverageAutoResizeEnjoyer;
                    }
                    else if (!options.HasFlag(CreationOptions.resizeWithParent) && value.HasFlag(CreationOptions.resizeWithParent))
                    {
                        oldParent.Resize += AverageAutoResizeEnjoyer;
                    }
                }
                options = value;
            }

        }

        public delegate void AdoptionHouseEventHandler(Control tak);

        [Obsolete("Designer Usage Only ONLY", true)]
        public UserControlButAdoptable()
        {
            this.options = CreationOptions.asUsual;
        }

        public UserControlButAdoptable(CreationOptions creationOptions)
        {
            this.options = creationOptions;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            oldParentWR.TryGetTarget(out var oldParent);
            if (oldParent == null && Parent != null)
            {
                OnAdopted(Parent);

                if (options.HasFlag(CreationOptions.resizeWithParent)) 
                { 
                    AverageAutoResizeEnjoyer(this, null); 
                    Parent.Resize += AverageAutoResizeEnjoyer; 
                }

            }
            else if (oldParent != null && Parent == null)
            {
                OnOrphaned(oldParent);
                if (options.HasFlag(CreationOptions.resizeWithParent)) oldParent.Resize -= AverageAutoResizeEnjoyer;
            }
            else if (options.HasFlag(CreationOptions.resizeWithParent))
            {
                oldParent.Resize -= AverageAutoResizeEnjoyer;
                Parent.Resize += AverageAutoResizeEnjoyer;
            }

            oldParentWR.SetTarget(Parent);
        }

        protected virtual void OnAdopted(Control e)
        {
            AdoptionHouseEventHandler handler = GotAdopted;
            handler?.Invoke(e);
        }

        protected virtual void OnOrphaned(Control e)
        {
            AdoptionHouseEventHandler handler = GotOrphaned;
            handler?.Invoke(e);
        }

        private void AverageAutoResizeEnjoyer(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(
                this.Parent.Size.Width > this.MinimumSize.Width ? this.Parent.Size.Width : this.MinimumSize.Width,
                this.Parent.Size.Height > this.MinimumSize.Height ? this.Parent.Size.Height : this.MinimumSize.Height
            );
        }
    }
}
