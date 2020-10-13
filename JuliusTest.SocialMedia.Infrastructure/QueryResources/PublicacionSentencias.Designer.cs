﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JuliusTest.SocialMedia.Infrastructure.QueryResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PublicacionSentencias {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PublicacionSentencias() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("JuliusTest.SocialMedia.Infrastructure.QueryResources.PublicacionSentencias", typeof(PublicacionSentencias).Assembly);
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
        ///   Looks up a localized string similar to AND {0} LIKE &apos;%{1}%&apos;.
        /// </summary>
        public static string LineaFiltrado {
            get {
                return ResourceManager.GetString("LineaFiltrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ORDER BY idPublicacion ASC, fechaCreacion DESC .
        /// </summary>
        public static string LineaOrdenamiento {
            get {
                return ResourceManager.GetString("LineaOrdenamiento", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY.
        /// </summary>
        public static string LineaPaginado {
            get {
                return ResourceManager.GetString("LineaPaginado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WHERE IdUsuario = {0}.
        /// </summary>
        public static string LineaWhere {
            get {
                return ResourceManager.GetString("LineaWhere", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT [IdPublicacion]
        ///      ,[IdUsuario]
        ///      ,[Titulo]
        ///      ,[Contenido]
        ///      ,[Imagen]
        ///      ,[FechaCreacion]
        ///	  ,[RecordsTotal] = COUNT(1) OVER()	
        ///	  ,[RecordsFiltered] = COUNT(1) OVER()
        ///  FROM [dbo].[Publicacion] With(NOLOCK).
        /// </summary>
        public static string PublicacionConsultaBase {
            get {
                return ResourceManager.GetString("PublicacionConsultaBase", resourceCulture);
            }
        }
    }
}
