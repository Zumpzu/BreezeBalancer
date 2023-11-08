// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/windpark.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcService {
  public static partial class WindParkManagement
  {
    static readonly string __ServiceName = "windpark.WindParkManagement";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcService.SetProductionTargetRequest> __Marshaller_windpark_SetProductionTargetRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.SetProductionTargetRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcService.SetProductionTargetResponse> __Marshaller_windpark_SetProductionTargetResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.SetProductionTargetResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcService.SetMarketPriceRequest> __Marshaller_windpark_SetMarketPriceRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.SetMarketPriceRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcService.SetMarketPriceResponse> __Marshaller_windpark_SetMarketPriceResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.SetMarketPriceResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcService.GetTurbineProductionsRequest> __Marshaller_windpark_GetTurbineProductionsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.GetTurbineProductionsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcService.GetTurbineProductionsResponse> __Marshaller_windpark_GetTurbineProductionsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcService.GetTurbineProductionsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcService.SetProductionTargetRequest, global::GrpcService.SetProductionTargetResponse> __Method_SetProductionTarget = new grpc::Method<global::GrpcService.SetProductionTargetRequest, global::GrpcService.SetProductionTargetResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SetProductionTarget",
        __Marshaller_windpark_SetProductionTargetRequest,
        __Marshaller_windpark_SetProductionTargetResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcService.SetMarketPriceRequest, global::GrpcService.SetMarketPriceResponse> __Method_SetMarketPrice = new grpc::Method<global::GrpcService.SetMarketPriceRequest, global::GrpcService.SetMarketPriceResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SetMarketPrice",
        __Marshaller_windpark_SetMarketPriceRequest,
        __Marshaller_windpark_SetMarketPriceResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcService.GetTurbineProductionsRequest, global::GrpcService.GetTurbineProductionsResponse> __Method_GetTurbineProductions = new grpc::Method<global::GrpcService.GetTurbineProductionsRequest, global::GrpcService.GetTurbineProductionsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetTurbineProductions",
        __Marshaller_windpark_GetTurbineProductionsRequest,
        __Marshaller_windpark_GetTurbineProductionsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcService.WindparkReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of WindParkManagement</summary>
    [grpc::BindServiceMethod(typeof(WindParkManagement), "BindService")]
    public abstract partial class WindParkManagementBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcService.SetProductionTargetResponse> SetProductionTarget(global::GrpcService.SetProductionTargetRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcService.SetMarketPriceResponse> SetMarketPrice(global::GrpcService.SetMarketPriceRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcService.GetTurbineProductionsResponse> GetTurbineProductions(global::GrpcService.GetTurbineProductionsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for WindParkManagement</summary>
    public partial class WindParkManagementClient : grpc::ClientBase<WindParkManagementClient>
    {
      /// <summary>Creates a new client for WindParkManagement</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public WindParkManagementClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for WindParkManagement that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public WindParkManagementClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected WindParkManagementClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected WindParkManagementClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcService.SetProductionTargetResponse SetProductionTarget(global::GrpcService.SetProductionTargetRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetProductionTarget(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcService.SetProductionTargetResponse SetProductionTarget(global::GrpcService.SetProductionTargetRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SetProductionTarget, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcService.SetProductionTargetResponse> SetProductionTargetAsync(global::GrpcService.SetProductionTargetRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetProductionTargetAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcService.SetProductionTargetResponse> SetProductionTargetAsync(global::GrpcService.SetProductionTargetRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SetProductionTarget, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcService.SetMarketPriceResponse SetMarketPrice(global::GrpcService.SetMarketPriceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetMarketPrice(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcService.SetMarketPriceResponse SetMarketPrice(global::GrpcService.SetMarketPriceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SetMarketPrice, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcService.SetMarketPriceResponse> SetMarketPriceAsync(global::GrpcService.SetMarketPriceRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetMarketPriceAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcService.SetMarketPriceResponse> SetMarketPriceAsync(global::GrpcService.SetMarketPriceRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SetMarketPrice, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcService.GetTurbineProductionsResponse GetTurbineProductions(global::GrpcService.GetTurbineProductionsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetTurbineProductions(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcService.GetTurbineProductionsResponse GetTurbineProductions(global::GrpcService.GetTurbineProductionsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetTurbineProductions, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcService.GetTurbineProductionsResponse> GetTurbineProductionsAsync(global::GrpcService.GetTurbineProductionsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetTurbineProductionsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcService.GetTurbineProductionsResponse> GetTurbineProductionsAsync(global::GrpcService.GetTurbineProductionsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetTurbineProductions, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override WindParkManagementClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new WindParkManagementClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(WindParkManagementBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SetProductionTarget, serviceImpl.SetProductionTarget)
          .AddMethod(__Method_SetMarketPrice, serviceImpl.SetMarketPrice)
          .AddMethod(__Method_GetTurbineProductions, serviceImpl.GetTurbineProductions).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, WindParkManagementBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SetProductionTarget, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcService.SetProductionTargetRequest, global::GrpcService.SetProductionTargetResponse>(serviceImpl.SetProductionTarget));
      serviceBinder.AddMethod(__Method_SetMarketPrice, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcService.SetMarketPriceRequest, global::GrpcService.SetMarketPriceResponse>(serviceImpl.SetMarketPrice));
      serviceBinder.AddMethod(__Method_GetTurbineProductions, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcService.GetTurbineProductionsRequest, global::GrpcService.GetTurbineProductionsResponse>(serviceImpl.GetTurbineProductions));
    }

  }
}
#endregion
