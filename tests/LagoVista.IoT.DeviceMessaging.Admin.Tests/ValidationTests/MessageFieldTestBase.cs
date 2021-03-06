﻿using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceMessaging.Admin.Tests.ValidationTests
{
    public class MessageFieldTestBase : MessageTestsBase
    {
        public DeviceMessageDefinitionField CreateValidMessageField(SearchLocations searchLocation, MessageContentTypes contentType = MessageContentTypes.JSON, ParameterTypes parameterType = ParameterTypes.String)
        {            
            var fld = new DeviceMessageDefinitionField();
            fld.Key = "key";
            fld.Name = "fld1";
            switch(parameterType)
            {
                case ParameterTypes.DateTime: fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.DateTime, Text = "Date Time" }; break;
                case ParameterTypes.Decimal: fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.Decimal, Text = "Decimal" }; break;
                case ParameterTypes.GeoLocation: fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.Geolocation, Text = "Geo Location" }; break;
                case ParameterTypes.Integer: fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.Integer, Text = "Integer" }; break;
                case ParameterTypes.State:
                    fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.State, Text = "State" };
                    fld.StateSet = new EntityHeader<StateSet>()
                    {
                        Id = "abc123",
                        Text = "text123"
                    };
                      
                    break;
                case ParameterTypes.String: fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.String, Text = "String" }; break;
                case ParameterTypes.TrueFalse: fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.TrueFalse, Text = "True/False" }; break;
                case ParameterTypes.ValueWithUnit:
                    fld.StorageType = new Core.Models.EntityHeader<DeviceAdmin.Models.ParameterTypes>() { Id = TypeSystem.ValueWithUnit, Text = "value with unit" };
                    fld.UnitSet = new EntityHeader<UnitSet>()
                    {
                        Id = "abc123",
                        Text="text123"
                    };
                    break;
            }
                       
            switch(searchLocation)
            {
                case SearchLocations.Body:
                    fld.SearchLocation = new Core.Models.EntityHeader<SearchLocations>() { Id = DeviceMessageDefinitionField.SearchLocation_Body, Text = "body" };
                    switch (contentType)
                    {
                        case MessageContentTypes.Binary:
                            fld.BinaryOffset = 32;
                            fld.ParsedBinaryFieldType = new Core.Models.EntityHeader<ParseBinaryValueType>() { Id = DeviceMessageDefinitionField.ParserStringType_String, Text = "uint64" };
                            break;
                        /*case MessageContentTypes.Custom:

                            break;*/
                        case MessageContentTypes.Delimited:
                            fld.DelimitedIndex = 3;
                            fld.ParsedStringFieldType = new Core.Models.EntityHeader<ParseStringValueType>() { Id = DeviceMessageDefinitionField.ParserStringType_String, Text = "abc123" };
                            break;
                        case MessageContentTypes.JSON:
                            fld.ParsedStringFieldType = new Core.Models.EntityHeader<ParseStringValueType>() { Id = DeviceMessageDefinitionField.ParserStringType_String, Text = "abc123" };
                            fld.JsonPath = "one.two.three";
                            break;
                        case MessageContentTypes.StringRegEx:
                            fld.ParsedStringFieldType = new Core.Models.EntityHeader<ParseStringValueType>() { Id = DeviceMessageDefinitionField.ParserStringType_String, Text = "abc123" };
                            fld.RegExGroupName = "somefield";
                            break;
                        case MessageContentTypes.StringPosition:
                            fld.ParsedStringFieldType = new Core.Models.EntityHeader<ParseStringValueType>() { Id = DeviceMessageDefinitionField.ParserStringType_String, Text = "abc123" };
                            fld.StartIndex = 5;
                            fld.Length = 5;
                            break;
                        case MessageContentTypes.XML:
                            fld.ParsedStringFieldType = new Core.Models.EntityHeader<ParseStringValueType>() { Id = DeviceMessageDefinitionField.ParserStringType_String, Text = "abc123" };
                            fld.XPath = "//foo/fee/fum";
                            break;
                    }
                    break;
                case SearchLocations.Header:
                    fld.SearchLocation = new Core.Models.EntityHeader<SearchLocations>() { Id = DeviceMessageDefinitionField.SearchLocation_Headers, Text = "headers" };
                    break;
                case SearchLocations.Path:
                    fld.SearchLocation = new Core.Models.EntityHeader<SearchLocations>() { Id = DeviceMessageDefinitionField.SearchLocation_Path, Text = "Path" };
                    fld.PathLocator = "/https/{foo}/fee";
                    break;
                case SearchLocations.QueryString:
                    fld.SearchLocation = new Core.Models.EntityHeader<SearchLocations>() { Id = DeviceMessageDefinitionField.SearchLocation_QueryString, Text = "Query String" };
                    fld.PathLocator = "fieldone";
                    break;
                case SearchLocations.Topic:
                    fld.SearchLocation = new Core.Models.EntityHeader<SearchLocations>() { Id = DeviceMessageDefinitionField.SearchLocation_Topic, Text = "Topic" };
                   
                    break;
            }            
            
            return fld;
        }        
    }
}
