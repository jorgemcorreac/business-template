﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The product name is too long.
        /// </summary>
        public static string Product_Name_MaxLength_ErrorMessage_The_product_name_is_too_long {
            get {
                return ResourceManager.GetString("Product_Name_MaxLength_ErrorMessage_The_product_name_is_too_long", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The product name is required.
        /// </summary>
        public static string Product_Name_Required_ErrorMessage_The_product_name_is_required {
            get {
                return ResourceManager.GetString("Product_Name_Required_ErrorMessage_The_product_name_is_required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The unit price must be greater than zero.
        /// </summary>
        public static string Product_UnitPrice_GreaterThanZero_The_unit_price_must_be_greater_than_zero {
            get {
                return ResourceManager.GetString("Product_UnitPrice_GreaterThanZero_The_unit_price_must_be_greater_than_zero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The year of the birth date must be greater 1900.
        /// </summary>
        public static string User_Birthdate_GreaterThan1900_The_year_of_the_birth_date_must_be_greater_1900 {
            get {
                return ResourceManager.GetString("User_Birthdate_GreaterThan1900_The_year_of_the_birth_date_must_be_greater_1900", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user name is too long.
        /// </summary>
        public static string User_Name_MaxLength_ErrorMessage_The_user_name_is_too_long {
            get {
                return ResourceManager.GetString("User_Name_MaxLength_ErrorMessage_The_user_name_is_too_long", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user name is required.
        /// </summary>
        public static string User_Name_Required_ErrorMessage_The_user_name_is_required {
            get {
                return ResourceManager.GetString("User_Name_Required_ErrorMessage_The_user_name_is_required", resourceCulture);
            }
        }
    }
}
