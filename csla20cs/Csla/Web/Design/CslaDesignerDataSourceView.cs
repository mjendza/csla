using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.Design;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Csla.Web.Design
{

  /// <summary>
  /// Object responsible for providing details about
  /// data binding to a specific CSLA .NET object.
  /// </summary>
  public class CslaDesignerDataSourceView : DesignerDataSourceView
  {

    private CslaDataSourceDesigner _owner = null;

    /// <summary>
    /// Creates an instance of the object.
    /// </summary>
    public CslaDesignerDataSourceView(CslaDataSourceDesigner owner, string viewName)
      : base(owner, viewName)
    {
      _owner = owner;
    }

    /// <summary>
    /// Returns a set of sample data used to populate
    /// controls at design time.
    /// </summary>
    /// <param name="minimumRows">Minimum number of sample rows
    /// to create.</param>
    /// <param name="isSampleData">Returns True if the data
    /// is sample data.</param>
    public override System.Collections.IEnumerable GetDesignTimeData(int minimumRows, out bool isSampleData)
    {

      IDataSourceViewSchema schema = this.Schema;
      DataTable result = new DataTable();

      // create the columns
      foreach (IDataSourceFieldSchema item in schema.GetFields())
        result.Columns.Add(item.Name, item.DataType);

      // create sample data
      for (int index = 1; index <= minimumRows; index++)
      {
        object[] values = new object[result.Columns.Count];
        int colIndex = 0;
        foreach (DataColumn col in result.Columns)
        {
          if (col.DataType.Equals(typeof(string)))
            values[colIndex] = "abc";
          else if (col.DataType.Equals(typeof(bool)))
            values[colIndex] = false;
          else if (col.DataType.IsPrimitive)
            values[colIndex] = index;
          else if (col.DataType.Equals(typeof(Guid)))
            values[colIndex] = Guid.NewGuid();
          else
            values[colIndex] = null;
          colIndex++;
        }
        result.LoadDataRow(values, LoadOption.OverwriteChanges);
      }

      isSampleData = true;
      return (System.Collections.IEnumerable)(new DataView(result));

    }

    /// <summary>
    /// Returns schema information corresponding to the properties
    /// of the CSLA .NET business object.
    /// </summary>
    /// <remarks>
    /// All public properties are returned except for those marked
    /// with the <see cref="BrowsableAttribute">Browsable attribute</see>
    /// as False.
    /// </remarks>
    public override IDataSourceViewSchema Schema
    {
      get
      {
        return new ObjectSchema(_owner.DataSourceControl.TypeAssemblyName,
          _owner.DataSourceControl.TypeName).GetViews()[0];
      }
    }

    /// <summary>
    /// Get a value indicating whether data binding can retrieve
    /// the total number of rows of data.
    /// </summary>
    public override bool CanRetrieveTotalRowCount
    {
      get { return true; }
    }

    /// <summary>
    /// Get a value indicating whether data binding can directly
    /// delete the object.
    /// </summary>
    /// <remarks>
    /// If this returns true, the web page must handle the
    /// <see cref="CslaDataSource.DeleteObject">DeleteObject</see>
    /// event.
    /// </remarks>
    public override bool CanDelete
    {
      get
      {
        Type objectType = CslaDataSource.GetType(
          _owner.DataSourceControl.TypeAssemblyName, _owner.DataSourceControl.TypeName);
        if (typeof(Csla.Core.IEditableObject).IsAssignableFrom(objectType))
          return true;
        else if (objectType.GetMethod("Remove") != null)
          return true;
        else
          return false;
      }
    }

    /// <summary>
    /// Get a value indicating whether data binding can directly
    /// insert an instance of the object.
    /// </summary>
    /// <remarks>
    /// If this returns true, the web page must handle the
    /// <see cref="CslaDataSource.InsertObject">InsertObject</see>
    /// event.
    /// </remarks>
    public override bool CanInsert
    {
      get
      {
        if (typeof(Csla.Core.IEditableObject).IsAssignableFrom(CslaDataSource.GetType(
          _owner.DataSourceControl.TypeAssemblyName, _owner.DataSourceControl.TypeName)))
          return true;
        else
          return false;
      }
    }

    /// <summary>
    /// Get a value indicating whether data binding can directly
    /// update or edit the object.
    /// </summary>
    /// <remarks>
    /// If this returns true, the web page must handle the
    /// <see cref="CslaDataSource.UpdateObject">UpdateObject</see>
    /// event.
    /// </remarks>
    public override bool CanUpdate
    {
      get
      {
        if (typeof(Csla.Core.IEditableObject).IsAssignableFrom(CslaDataSource.GetType(
          _owner.DataSourceControl.TypeAssemblyName, _owner.DataSourceControl.TypeName)))
          return true;
        else
          return false;
      }
    }

    /// <summary>
    /// Gets a value indicating whether the data source supports
    /// paging.
    /// </summary>
    public override bool CanPage
    {
      get { return false; }
    }

    /// <summary>
    /// Gets a value indicating whether the data source supports
    /// sorting.
    /// </summary>
    public override bool CanSort
    {
      get { return false; }
    }
  }
}

