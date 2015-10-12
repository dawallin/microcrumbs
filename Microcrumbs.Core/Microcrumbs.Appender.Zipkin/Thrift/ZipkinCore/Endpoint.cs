/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;


#if !SILVERLIGHT
[Serializable]
#endif
public partial class Endpoint : TBase
{
  private int _ipv4;
  private short _port;
  private string _service_name;

  public int Ipv4
  {
    get
    {
      return _ipv4;
    }
    set
    {
      __isset.ipv4 = true;
      this._ipv4 = value;
    }
  }

  public short Port
  {
    get
    {
      return _port;
    }
    set
    {
      __isset.port = true;
      this._port = value;
    }
  }

  public string Service_name
  {
    get
    {
      return _service_name;
    }
    set
    {
      __isset.service_name = true;
      this._service_name = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool ipv4;
    public bool port;
    public bool service_name;
  }

  public Endpoint() {
  }

  public void Read (TProtocol iprot)
  {
    TField field;
    iprot.ReadStructBegin();
    while (true)
    {
      field = iprot.ReadFieldBegin();
      if (field.Type == TType.Stop) { 
        break;
      }
      switch (field.ID)
      {
        case 1:
          if (field.Type == TType.I32) {
            Ipv4 = iprot.ReadI32();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 2:
          if (field.Type == TType.I16) {
            Port = iprot.ReadI16();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 3:
          if (field.Type == TType.String) {
            Service_name = iprot.ReadString();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        default: 
          TProtocolUtil.Skip(iprot, field.Type);
          break;
      }
      iprot.ReadFieldEnd();
    }
    iprot.ReadStructEnd();
  }

  public void Write(TProtocol oprot) {
    TStruct struc = new TStruct("Endpoint");
    oprot.WriteStructBegin(struc);
    TField field = new TField();
    if (__isset.ipv4) {
      field.Name = "ipv4";
      field.Type = TType.I32;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32(Ipv4);
      oprot.WriteFieldEnd();
    }
    if (__isset.port) {
      field.Name = "port";
      field.Type = TType.I16;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteI16(Port);
      oprot.WriteFieldEnd();
    }
    if (Service_name != null && __isset.service_name) {
      field.Name = "service_name";
      field.Type = TType.String;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Service_name);
      oprot.WriteFieldEnd();
    }
    oprot.WriteFieldStop();
    oprot.WriteStructEnd();
  }

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("Endpoint(");
    bool __first = true;
    if (__isset.ipv4) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Ipv4: ");
      __sb.Append(Ipv4);
    }
    if (__isset.port) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Port: ");
      __sb.Append(Port);
    }
    if (Service_name != null && __isset.service_name) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Service_name: ");
      __sb.Append(Service_name);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

