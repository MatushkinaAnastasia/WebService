// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: gradeCalculation.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

public static partial class GradeCalculation
{
  static readonly string __ServiceName = "GradeCalculation";

  static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
  {
    #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
    if (message is global::Google.Protobuf.IBufferMessage)
    {
      context.SetPayloadLength(message.CalculateSize());
      global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
      context.Complete();
      return;
    }
    #endif
    context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
  }

  static class __Helper_MessageCache<T>
  {
    public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
  }

  static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
  {
    #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
    if (__Helper_MessageCache<T>.IsBufferMessage)
    {
      return parser.ParseFrom(context.PayloadAsReadOnlySequence());
    }
    #endif
    return parser.ParseFrom(context.PayloadAsNewBuffer());
  }

  static readonly grpc::Marshaller<global::Student> __Marshaller_Student = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Student.Parser));
  static readonly grpc::Marshaller<global::Grade> __Marshaller_Grade = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Grade.Parser));

  static readonly grpc::Method<global::Student, global::Grade> __Method_CalculateGrade = new grpc::Method<global::Student, global::Grade>(
      grpc::MethodType.Unary,
      __ServiceName,
      "CalculateGrade",
      __Marshaller_Student,
      __Marshaller_Grade);

  /// <summary>Service descriptor</summary>
  public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
  {
    get { return global::GradeCalculationReflection.Descriptor.Services[0]; }
  }

  /// <summary>Base class for server-side implementations of GradeCalculation</summary>
  [grpc::BindServiceMethod(typeof(GradeCalculation), "BindService")]
  public abstract partial class GradeCalculationBase
  {
    public virtual global::System.Threading.Tasks.Task<global::Grade> CalculateGrade(global::Student request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

  }

  /// <summary>Creates service definition that can be registered with a server</summary>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static grpc::ServerServiceDefinition BindService(GradeCalculationBase serviceImpl)
  {
    return grpc::ServerServiceDefinition.CreateBuilder()
        .AddMethod(__Method_CalculateGrade, serviceImpl.CalculateGrade).Build();
  }

  /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
  /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
  /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static void BindService(grpc::ServiceBinderBase serviceBinder, GradeCalculationBase serviceImpl)
  {
    serviceBinder.AddMethod(__Method_CalculateGrade, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Student, global::Grade>(serviceImpl.CalculateGrade));
  }

}
#endregion
