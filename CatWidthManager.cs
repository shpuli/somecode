using System;
using Nptv.Presentation.UI;

namespace Nptv.Applications.Test.Entities
{
    /// <summary>
    /// Represents a class with a property that can be set by any method. Used for user's AttachedProperty test.
    /// </summary>
    public static class CatWidthManager
    {
        /// <summary>
        /// Registers a dependency property with the specified property name, property type, and owner type.
        /// </summary>
        public static readonly DependencyProperty<Single> AttachedWidthProperty =
         DependencyProperty.RegisterAttached("AttachedWidth", typeof(CatWidthManager), new PropertyMetadata<Single, UIElement>(Single.NaN, AttachedWidthChanged));

        /// <summary>
        /// Gets the width for the <see cref="UIElement"/>.
        /// </summary>
        public static Single GetAttachedWidth(UIElement element)
        {
            return element.GetValue(AttachedWidthProperty);
        }

        /// <summary>
        /// Sets the width for the <see cref="UIElement"/>.
        /// </summary>
        public static void SetAttachedtWidth(UIElement element, Single value)
        {
            element.SetValue(AttachedWidthProperty, value);
        }

        /// <summary>
        /// The <see cref="Action"/> that will be invoked after each setting of the property.
        /// </summary>
        /// <param name="element">The <see cref="UIElement"/> to wich property will be set.</param>
        /// <param name="args">A value of property.</param>
        private static void AttachedWidthChanged(UIElement element, DependencyPropertyChangedEventArgs<Single> args)
        {
            element.Width = args.NewValueEntry.Value;
        }
    }
}
