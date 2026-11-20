package com.google.mediapipe.tasks.core;

import com.google.mediapipe.calculator.proto.InferenceCalculatorProto;
import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.core.proto.AccelerationProto;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.mediapipe.tasks.core.proto.ExternalFileProto;
import com.google.protobuf.Any;
import com.google.protobuf.ByteString;
import java.nio.ByteBuffer;
import java.util.Objects;
import java.util.Optional;
import java.util.function.Consumer;

/* JADX INFO: loaded from: classes3.dex */
public abstract class TaskOptions {
    public Any convertToAnyProto() {
        return null;
    }

    public CalculatorOptionsProto.CalculatorOptions convertToCalculatorOptionsProto() {
        return null;
    }

    protected BaseOptionsProto.BaseOptions convertBaseOptionsToProto(BaseOptions baseOptions) {
        final ExternalFileProto.ExternalFile.Builder builderNewBuilder = ExternalFileProto.ExternalFile.newBuilder();
        Optional<String> optionalModelAssetPath = baseOptions.modelAssetPath();
        Objects.requireNonNull(builderNewBuilder);
        optionalModelAssetPath.ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda3
            @Override // java.util.function.Consumer
            public final void accept(Object obj) {
                builderNewBuilder.setFileName((String) obj);
            }
        });
        baseOptions.modelAssetFileDescriptor().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda4
            @Override // java.util.function.Consumer
            public final void accept(Object obj) {
                builderNewBuilder.setFileDescriptorMeta(ExternalFileProto.FileDescriptorMeta.newBuilder().setFd(((Integer) obj).intValue()).build());
            }
        });
        baseOptions.modelAssetBuffer().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda5
            @Override // java.util.function.Consumer
            public final void accept(Object obj) {
                TaskOptions.m437$r8$lambda$MKwyVrYZdZrY9Kx4k7zimwvqvY(builderNewBuilder, (ByteBuffer) obj);
            }
        });
        final AccelerationProto.Acceleration.Builder builderNewBuilder2 = AccelerationProto.Acceleration.newBuilder();
        int i = AnonymousClass1.$SwitchMap$com$google$mediapipe$tasks$core$Delegate[baseOptions.delegate().ordinal()];
        if (i == 1) {
            builderNewBuilder2.setTflite(InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.TfLite.getDefaultInstance());
            baseOptions.delegateOptions().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda6
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    TaskOptions.$r8$lambda$lhOkFJ3_jgN9boMnyPIhVtmtGhg(this.f$0, builderNewBuilder2, (BaseOptions.DelegateOptions) obj);
                }
            });
        } else if (i == 2) {
            builderNewBuilder2.setGpu(InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.Gpu.newBuilder().setUseAdvancedGpuApi(true).build());
            baseOptions.delegateOptions().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda7
                @Override // java.util.function.Consumer
                public final void accept(Object obj) {
                    TaskOptions.$r8$lambda$h6RiN82CjQiWaENkBD7jREQN5zI(this.f$0, builderNewBuilder2, (BaseOptions.DelegateOptions) obj);
                }
            });
        }
        return BaseOptionsProto.BaseOptions.newBuilder().setModelAsset(builderNewBuilder.build()).setAcceleration(builderNewBuilder2.build()).build();
    }

    /* JADX INFO: renamed from: $r8$lambda$MKwyVrYZ-dZrY9Kx4k7zimwvqvY, reason: not valid java name */
    public static /* synthetic */ void m437$r8$lambda$MKwyVrYZdZrY9Kx4k7zimwvqvY(ExternalFileProto.ExternalFile.Builder builder, ByteBuffer byteBuffer) {
        byteBuffer.rewind();
        builder.setFileContent(ByteString.copyFrom(byteBuffer));
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.core.TaskOptions$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$com$google$mediapipe$tasks$core$Delegate;

        static {
            int[] iArr = new int[Delegate.values().length];
            $SwitchMap$com$google$mediapipe$tasks$core$Delegate = iArr;
            try {
                iArr[Delegate.CPU.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$com$google$mediapipe$tasks$core$Delegate[Delegate.GPU.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$lhOkFJ3_jgN9boMnyPIhVtmtGhg(TaskOptions taskOptions, AccelerationProto.Acceleration.Builder builder, BaseOptions.DelegateOptions delegateOptions) {
        taskOptions.getClass();
        taskOptions.setDelegateOptions(builder, (BaseOptions.DelegateOptions.CpuOptions) delegateOptions);
    }

    public static /* synthetic */ void $r8$lambda$h6RiN82CjQiWaENkBD7jREQN5zI(TaskOptions taskOptions, AccelerationProto.Acceleration.Builder builder, BaseOptions.DelegateOptions delegateOptions) {
        taskOptions.getClass();
        taskOptions.setDelegateOptions(builder, (BaseOptions.DelegateOptions.GpuOptions) delegateOptions);
    }

    private void setDelegateOptions(AccelerationProto.Acceleration.Builder builder, BaseOptions.DelegateOptions.CpuOptions cpuOptions) {
        builder.setTflite(InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.TfLite.getDefaultInstance());
    }

    private void setDelegateOptions(AccelerationProto.Acceleration.Builder builder, BaseOptions.DelegateOptions.GpuOptions gpuOptions) {
        final InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.Gpu.Builder useAdvancedGpuApi = InferenceCalculatorProto.InferenceCalculatorOptions.Delegate.Gpu.newBuilder().setUseAdvancedGpuApi(true);
        Optional<String> optionalCachedKernelPath = gpuOptions.cachedKernelPath();
        Objects.requireNonNull(useAdvancedGpuApi);
        optionalCachedKernelPath.ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda0
            @Override // java.util.function.Consumer
            public final void accept(Object obj) {
                useAdvancedGpuApi.setCachedKernelPath((String) obj);
            }
        });
        gpuOptions.serializedModelDir().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda1
            @Override // java.util.function.Consumer
            public final void accept(Object obj) {
                useAdvancedGpuApi.setSerializedModelDir((String) obj);
            }
        });
        gpuOptions.modelToken().ifPresent(new Consumer() { // from class: com.google.mediapipe.tasks.core.TaskOptions$$ExternalSyntheticLambda2
            @Override // java.util.function.Consumer
            public final void accept(Object obj) {
                useAdvancedGpuApi.setModelToken((String) obj);
            }
        });
        builder.setGpu(useAdvancedGpuApi.build());
    }
}
