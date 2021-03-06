﻿using Mvvm;
using PLCDiagnostic.Data;
using PLCDiagnostic.PLC;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCDiagnostic.Models
{
    public class PlcIO : BindableBase
    {
        private string _value;
        private string _writeAddress;
        private string _writeValue;
        private string _addressController = "127.0.0.1";
        private CpuTypeModel cpuTypeModel = new CpuTypeModel()
        {
            Type = CpuType.S71500
        };
        public string Name { set; get; }
        public CpuTypeModel CPUType {
            set
            {
                SetProperty(ref cpuTypeModel, value);
            }
            get
            {
                return cpuTypeModel;
            }
        }
        public int PlcId { set; get; }
        public string Address { set; get; }
        public string Controller
        {
            set
            {
                SetProperty(ref _addressController, value);
            }
            get
            {
                return _addressController;
            }
        }
        public string Value {
            set
            {
                SetProperty(ref _value, value);
            }
            get
            {
                return _value;
            }
        }
        public string WriteAddress {
            set
            {
                SetProperty(ref _writeAddress, value);
            }
            get
            {
                if (string.IsNullOrEmpty(_writeAddress))
                {
                    return Address;
                }
                return _writeAddress;
            }
        }
        public string WriteValue
        {
            set
            {
                SetProperty(ref _writeValue, value);
            }
            get
            {
               
                return _writeValue;
            }
        }
        public string ValueToDisplay
        {
            get
            {
                return Value;
            }
        }
        public bool IsEnable { set; get; }
        public int Type { set; get; }
        public string TypeName
        {
            get
            {
                if (Type==IOTypeConstants.BOOL_TYPE)
                {
                    return "Boolean";
                } else if (Type == IOTypeConstants.FLOAT_TYPE)
                {
                    return "Float";
                } else if (Type == IOTypeConstants.INT_TYPE)
                {
                    return "Int";
                } else if (Type == IOTypeConstants.BYTE_TYPE)
                {
                    return "Byte";
                }
                else
                {
                    return "Word";
                }
            }
            set
            {
                if ("Boolean"==value)
                {
                    Type = IOTypeConstants.BOOL_TYPE;
                }else
                if ("Float" == value)
                {
                    Type = IOTypeConstants.FLOAT_TYPE;
                } else
                if ("Int" == value)
                {
                    Type = IOTypeConstants.INT_TYPE;
                } else if ("Byte" == value)
                
                {
                    Type = IOTypeConstants.BYTE_TYPE;
                } else
                {
                    Type = IOTypeConstants.WORD_TYPE;
                }
               
            }
        }
    }
}
