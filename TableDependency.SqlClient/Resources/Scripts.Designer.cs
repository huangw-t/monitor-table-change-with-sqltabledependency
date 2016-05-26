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
        ///	BEGIN TRANSACTION
        ///
        ///	IF EXISTS (SELECT * FROM sys.service_queues WHERE name = N&apos;{0}&apos;)
        ///	BEGIN
        ///		IF (SELECT COUNT(*) FROM [{0}] WHERE message_type_name = &apos;http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer&apos;) &gt; 0 
        ///		BEGIN 
        ///			{1}
        ///		END 
        ///	END
        ///
        ///	COMMIT TRANSACTION
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
        ///   Looks up a localized string similar to declare @schema_id INT
        ///select @schema_id = schema_id from sys.schemas where name = &apos;{2}&apos;
        ///
        ///IF EXISTS (SELECT * FROM sys.service_queues WHERE schema_id = @schema_id AND name = N&apos;{0}&apos;) EXEC (&apos;ALTER QUEUE {2}.[{0}] WITH ACTIVATION (STATUS = OFF)&apos;);
        ///
        ///IF EXISTS (SELECT * FROM sys.objects WHERE schema_id = @schema_id AND name = N&apos;tr_{0}&apos;) DROP TRIGGER {2}.[tr_{0}];
        ///IF EXISTS (SELECT * FROM sys.services WHERE name = N&apos;{0}&apos;) DROP SERVICE [{0}];
        ///IF EXISTS (SELECT * FROM sys.service_queues WHERE schema_id = @sc [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ScriptDropAll {
            get {
                return ResourceManager.GetString("ScriptDropAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF ({0}) BEGIN
        ///    SET @dmlType = &apos;{3}&apos;
        ///    INSERT INTO @modifiedRecordsTable SELECT {2} FROM INSERTED
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
        ///INSERT INTO @modifiedRecordsTable SELECT {1} FROM INSERTED
        ///{3}.
        /// </summary>
        internal static string TriggerUpdateWithoutColumns {
            get {
                return ResourceManager.GetString("TriggerUpdateWithoutColumns", resourceCulture);
            }
        }
    }
}
