﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace Csla.Test.Data
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DataPortalTestDatabaseEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DataPortalTestDatabaseEntities object using the connection string found in the 'DataPortalTestDatabaseEntities' section of the application configuration file.
        /// </summary>
        public DataPortalTestDatabaseEntities() : base("name=DataPortalTestDatabaseEntities", "DataPortalTestDatabaseEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DataPortalTestDatabaseEntities object.
        /// </summary>
        public DataPortalTestDatabaseEntities(string connectionString) : base(connectionString, "DataPortalTestDatabaseEntities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DataPortalTestDatabaseEntities object.
        /// </summary>
        public DataPortalTestDatabaseEntities(EntityConnection connection) : base(connection, "DataPortalTestDatabaseEntities")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Table2> Table2
        {
            get
            {
                if ((_Table2 == null))
                {
                    _Table2 = base.CreateObjectSet<Table2>("Table2");
                }
                return _Table2;
            }
        }
        private ObjectSet<Table2> _Table2;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Table2 EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTable2(Table2 table2)
        {
            base.AddObject("Table2", table2);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DataPortalTestDatabaseModel", Name="Table2")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Table2 : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Table2 object.
        /// </summary>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="smallColumn">Initial value of the SmallColumn property.</param>
        public static Table2 CreateTable2(global::System.String firstName, global::System.String lastName, global::System.String smallColumn)
        {
            Table2 table2 = new Table2();
            table2.FirstName = firstName;
            table2.LastName = lastName;
            table2.SmallColumn = smallColumn;
            return table2;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    OnFirstNameChanging(value);
                    ReportPropertyChanging("FirstName");
                    _FirstName = StructuralObject.SetValidValue(value, false, "FirstName");
                    ReportPropertyChanged("FirstName");
                    OnFirstNameChanged();
                }
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    OnLastNameChanging(value);
                    ReportPropertyChanging("LastName");
                    _LastName = StructuralObject.SetValidValue(value, false, "LastName");
                    ReportPropertyChanged("LastName");
                    OnLastNameChanged();
                }
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String SmallColumn
        {
            get
            {
                return _SmallColumn;
            }
            set
            {
                if (_SmallColumn != value)
                {
                    OnSmallColumnChanging(value);
                    ReportPropertyChanging("SmallColumn");
                    _SmallColumn = StructuralObject.SetValidValue(value, false, "SmallColumn");
                    ReportPropertyChanged("SmallColumn");
                    OnSmallColumnChanged();
                }
            }
        }
        private global::System.String _SmallColumn;
        partial void OnSmallColumnChanging(global::System.String value);
        partial void OnSmallColumnChanged();

        #endregion

    }

    #endregion

}