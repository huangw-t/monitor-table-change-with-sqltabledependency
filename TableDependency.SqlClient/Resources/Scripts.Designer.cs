﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TableDependency.SqlClient.Resources {
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
    internal class Scripts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Scripts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TableDependency.SqlClient.Resources.Scripts", typeof(Scripts).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE PROCEDURE {2}.[{0}_QueueActivation] AS 
        ///BEGIN 
        ///	SET NOCOUNT ON;
        ///
        ///	RECEIVE TOP(0) [conversation_handle]
        ///	FROM {2}.[{0}]
        ///
        ///	IF EXISTS (SELECT * FROM sys.service_queues WITH(NOLOCK) WHERE name = N&apos;{0}&apos;)
        ///	BEGIN
        ///		IF ((SELECT COUNT(*) FROM {2}.[{0}] WITH(NOLOCK) WHERE message_type_name = N&apos;http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer&apos;) &gt; 0)
        ///		BEGIN 
        ///			{1}
        ///		END 
        ///	END
        ///END.
        /// </summary>
        internal static string CreateProcedureQueueActivation {
            get {
                return ResourceManager.GetString("CreateProcedureQueueActivation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TRIGGER [tr_{0}] ON {1} AFTER {13} AS 
        ///BEGIN
        ///	SET NOCOUNT ON;
        ///
        ///	DECLARE @rowsToProcess INT
        ///	DECLARE @currentRow INT
        ///	DECLARE @h AS UNIQUEIDENTIFIER
        ///	DECLARE @records XML
        ///	DECLARE @theMessageContainer NVARCHAR(MAX)
        ///	DECLARE @dmlType NVARCHAR(10)
        ///	DECLARE @modifiedRecordsTable TABLE ([RowNumber] INT IDENTITY(1, 1), {2})
        ///	{5}
        ///	
        ///	IF NOT EXISTS(SELECT * FROM INSERTED)
        ///	BEGIN
        ///		SET @dmlType = &apos;{12}&apos;
        ///		INSERT INTO @modifiedRecordsTable SELECT {3} FROM DELETED
        ///	END
        ///	ELSE
        ///	BEGIN
        ///		IF NOT E [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreateTrigger {
            get {
                return ResourceManager.GetString("CreateTrigger", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT DB_NAME() AS TABLE_CATALOG,
        ///SCHEMA_NAME(o.schema_id) AS TABLE_SCHEMA,
        ///o.name	AS TABLE_NAME,
        ///c.name	AS COLUMN_NAME,
        ///COLUMNPROPERTY(c.object_id, c.name, &apos;ordinal&apos;) AS ORDINAL_POSITION,
        ///convert(nvarchar(4000), OBJECT_DEFINITION(c.default_object_id))	AS COLUMN_DEFAULT,
        ///convert(varchar(3), CASE c.is_nullable WHEN 1 THEN &apos;YES&apos; ELSE &apos;NO&apos; END)	AS IS_NULLABLE,
        ///ISNULL(TYPE_NAME(c.system_type_id), t.name)	AS DATA_TYPE,
        ///COLUMNPROPERTY(c.object_id, c.name, &apos;charmaxlen&apos;) AS CHARACTER_MAXIMUM_LENGTH,
        ///COLUM [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InformationSchemaColumns {
            get {
                return ResourceManager.GetString("InformationSchemaColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT COUNT(*) FROM sys.objects o LEFT JOIN sys.schemas s ON s.schema_id = o.schema_id WHERE o.type IN (&apos;U&apos;, &apos;V&apos;) and o.name = &apos;{0}&apos; and s.name = &apos;{1}&apos;.
        /// </summary>
        internal static string InformationSchemaTables {
            get {
                return ResourceManager.GetString("InformationSchemaTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @schema_id INT
        ///DECLARE @conversation_handle UNIQUEIDENTIFIER
        ///
        ///SELECT @schema_id = schema_id FROM sys.schemas WHERE name = N&apos;{2}&apos;;
        ///
        ///IF EXISTS (SELECT * FROM sys.objects WHERE schema_id = @schema_id AND name = N&apos;tr_{0}&apos;) DROP TRIGGER [{2}].[tr_{0}];
        ///IF EXISTS (SELECT * FROM sys.service_queues WITH(NOLOCK) WHERE schema_id = @schema_id AND name = N&apos;{0}&apos;) EXEC (N&apos;ALTER QUEUE [{2}].[{0}] WITH ACTIVATION (STATUS = OFF)&apos;);
        ///
        ///SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoin [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ScriptDropAll {
            get {
                return ResourceManager.GetString("ScriptDropAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///Security Audit Report
        ///1) List all access provisioned to a sql user or windows user/group directly 
        ///2) List all access provisioned to a sql user or windows user/group through a database or application role
        ///3) List all access provisioned to the public role
        ///
        ///Columns Returned:
        ///UserName        : SQL or Windows/Active Directory user cccount.  This could also be an Active Directory group.
        ///UserType        : Value will be either &apos;SQL User&apos; or &apos;Windows User&apos;.  This reflects the type of user defined for the [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SelectUserGrants {
            get {
                return ResourceManager.GetString("SelectUserGrants", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF ({0}) BEGIN
        ///    SET @dmlType = &apos;{3}&apos;
        ///    INSERT INTO @modifiedRecordsTable SELECT {2} FROM
        ///    {4}
        ///END
        ///ELSE BEGIN
        ///    RETURN
        ///END.
        /// </summary>
        internal static string TriggerUpdateWithColumns {
            get {
                return ResourceManager.GetString("TriggerUpdateWithColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SET @dmlType = &apos;{2}&apos;
        ///INSERT INTO @modifiedRecordsTable SELECT {1} FROM
        ///{3}.
        /// </summary>
        internal static string TriggerUpdateWithoutColumns {
            get {
                return ResourceManager.GetString("TriggerUpdateWithoutColumns", resourceCulture);
            }
        }
    }
}
