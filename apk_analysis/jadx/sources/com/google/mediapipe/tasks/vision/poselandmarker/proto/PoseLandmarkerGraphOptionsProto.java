package com.google.mediapipe.tasks.vision.poselandmarker.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.mediapipe.tasks.vision.posedetector.proto.PoseDetectorGraphOptionsProto;
import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import com.google.protobuf.WireFormat;
import java.io.InputStream;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public final class PoseLandmarkerGraphOptionsProto {

    public interface PoseLandmarkerGraphOptionsOrBuilder extends MessageLiteOrBuilder {
        BaseOptionsProto.BaseOptions getBaseOptions();

        float getMinTrackingConfidence();

        PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions getPoseDetectorGraphOptions();

        PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions getPoseLandmarksDetectorGraphOptions();

        boolean hasBaseOptions();

        boolean hasMinTrackingConfidence();

        boolean hasPoseDetectorGraphOptions();

        boolean hasPoseLandmarksDetectorGraphOptions();
    }

    private PoseLandmarkerGraphOptionsProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) PoseLandmarkerGraphOptions.ext);
    }

    public static final class PoseLandmarkerGraphOptions extends GeneratedMessageLite<PoseLandmarkerGraphOptions, Builder> implements PoseLandmarkerGraphOptionsOrBuilder {
        public static final int BASE_OPTIONS_FIELD_NUMBER = 1;
        private static final PoseLandmarkerGraphOptions DEFAULT_INSTANCE;
        public static final int EXT_FIELD_NUMBER = 516587230;
        public static final int MIN_TRACKING_CONFIDENCE_FIELD_NUMBER = 4;
        private static volatile Parser<PoseLandmarkerGraphOptions> PARSER = null;
        public static final int POSE_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 2;
        public static final int POSE_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 3;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, PoseLandmarkerGraphOptions> ext;
        private BaseOptionsProto.BaseOptions baseOptions_;
        private int bitField0_;
        private float minTrackingConfidence_ = 0.5f;
        private PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions_;
        private PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions_;

        @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLiteOrBuilder
        public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
            return super.getDefaultInstanceForType();
        }

        @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
        public /* bridge */ /* synthetic */ MessageLite.Builder newBuilderForType() {
            return super.newBuilderForType();
        }

        @Override // com.google.protobuf.GeneratedMessageLite, com.google.protobuf.MessageLite
        public /* bridge */ /* synthetic */ MessageLite.Builder toBuilder() {
            return super.toBuilder();
        }

        private PoseLandmarkerGraphOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public boolean hasBaseOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public BaseOptionsProto.BaseOptions getBaseOptions() {
            BaseOptionsProto.BaseOptions baseOptions = this.baseOptions_;
            return baseOptions == null ? BaseOptionsProto.BaseOptions.getDefaultInstance() : baseOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
            baseOptions.getClass();
            this.baseOptions_ = baseOptions;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
            baseOptions.getClass();
            BaseOptionsProto.BaseOptions baseOptions2 = this.baseOptions_;
            if (baseOptions2 != null && baseOptions2 != BaseOptionsProto.BaseOptions.getDefaultInstance()) {
                this.baseOptions_ = BaseOptionsProto.BaseOptions.newBuilder(this.baseOptions_).mergeFrom(baseOptions).buildPartial();
            } else {
                this.baseOptions_ = baseOptions;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearBaseOptions() {
            this.baseOptions_ = null;
            this.bitField0_ &= -2;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public boolean hasPoseDetectorGraphOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions getPoseDetectorGraphOptions() {
            PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions = this.poseDetectorGraphOptions_;
            return poseDetectorGraphOptions == null ? PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.getDefaultInstance() : poseDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
            poseDetectorGraphOptions.getClass();
            this.poseDetectorGraphOptions_ = poseDetectorGraphOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergePoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
            poseDetectorGraphOptions.getClass();
            PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions2 = this.poseDetectorGraphOptions_;
            if (poseDetectorGraphOptions2 != null && poseDetectorGraphOptions2 != PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.getDefaultInstance()) {
                this.poseDetectorGraphOptions_ = PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.newBuilder(this.poseDetectorGraphOptions_).mergeFrom(poseDetectorGraphOptions).buildPartial();
            } else {
                this.poseDetectorGraphOptions_ = poseDetectorGraphOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPoseDetectorGraphOptions() {
            this.poseDetectorGraphOptions_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public boolean hasPoseLandmarksDetectorGraphOptions() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions getPoseLandmarksDetectorGraphOptions() {
            PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions = this.poseLandmarksDetectorGraphOptions_;
            return poseLandmarksDetectorGraphOptions == null ? PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.getDefaultInstance() : poseLandmarksDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
            poseLandmarksDetectorGraphOptions.getClass();
            this.poseLandmarksDetectorGraphOptions_ = poseLandmarksDetectorGraphOptions;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergePoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
            poseLandmarksDetectorGraphOptions.getClass();
            PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions2 = this.poseLandmarksDetectorGraphOptions_;
            if (poseLandmarksDetectorGraphOptions2 != null && poseLandmarksDetectorGraphOptions2 != PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.getDefaultInstance()) {
                this.poseLandmarksDetectorGraphOptions_ = PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.newBuilder(this.poseLandmarksDetectorGraphOptions_).mergeFrom(poseLandmarksDetectorGraphOptions).buildPartial();
            } else {
                this.poseLandmarksDetectorGraphOptions_ = poseLandmarksDetectorGraphOptions;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPoseLandmarksDetectorGraphOptions() {
            this.poseLandmarksDetectorGraphOptions_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public boolean hasMinTrackingConfidence() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
        public float getMinTrackingConfidence() {
            return this.minTrackingConfidence_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMinTrackingConfidence(float f) {
            this.bitField0_ |= 8;
            this.minTrackingConfidence_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMinTrackingConfidence() {
            this.bitField0_ &= -9;
            this.minTrackingConfidence_ = 0.5f;
        }

        public static PoseLandmarkerGraphOptions parseFrom(ByteBuffer byteBuffer) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static PoseLandmarkerGraphOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static PoseLandmarkerGraphOptions parseFrom(ByteString byteString) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static PoseLandmarkerGraphOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static PoseLandmarkerGraphOptions parseFrom(byte[] bArr) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static PoseLandmarkerGraphOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static PoseLandmarkerGraphOptions parseFrom(InputStream inputStream) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PoseLandmarkerGraphOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PoseLandmarkerGraphOptions parseDelimitedFrom(InputStream inputStream) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static PoseLandmarkerGraphOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static PoseLandmarkerGraphOptions parseFrom(CodedInputStream codedInputStream) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static PoseLandmarkerGraphOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (PoseLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(PoseLandmarkerGraphOptions poseLandmarkerGraphOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(poseLandmarkerGraphOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<PoseLandmarkerGraphOptions, Builder> implements PoseLandmarkerGraphOptionsOrBuilder {
            /* synthetic */ Builder(AnonymousClass1 anonymousClass1) {
                this();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite build() {
                return super.build();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite buildPartial() {
                return super.buildPartial();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder clear() {
                return super.clear();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            /* JADX INFO: renamed from: clone */
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mo436clone() {
                return super.mo436clone();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            /* JADX INFO: renamed from: clone */
            public /* bridge */ /* synthetic */ MessageLite.Builder mo436clone() {
                return super.mo436clone();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
            /* JADX INFO: renamed from: clone */
            public /* bridge */ /* synthetic */ Object mo436clone() {
                return super.mo436clone();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.MessageLiteOrBuilder
            public /* bridge */ /* synthetic */ MessageLite getDefaultInstanceForType() {
                return super.getDefaultInstanceForType();
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder
            protected /* bridge */ /* synthetic */ AbstractMessageLite.Builder internalMergeFrom(AbstractMessageLite abstractMessageLite) {
                return super.internalMergeFrom((GeneratedMessageLite) abstractMessageLite);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(codedInputStream, extensionRegistryLite);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                return super.mergeFrom(bArr, i, i2);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ AbstractMessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString) {
                return super.mergeFrom(byteString);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(byteString, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream) {
                return super.mergeFrom(codedInputStream);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(codedInputStream, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(MessageLite messageLite) {
                return super.mergeFrom(messageLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream) {
                return super.mergeFrom(inputStream);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(inputStream, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr) {
                return super.mergeFrom(bArr);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2) {
                return super.mergeFrom(bArr, i, i2);
            }

            @Override // com.google.protobuf.GeneratedMessageLite.Builder, com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, int i, int i2, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(bArr, i, i2, extensionRegistryLite);
            }

            @Override // com.google.protobuf.AbstractMessageLite.Builder, com.google.protobuf.MessageLite.Builder
            public /* bridge */ /* synthetic */ MessageLite.Builder mergeFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return super.mergeFrom(bArr, extensionRegistryLite);
            }

            private Builder() {
                super(PoseLandmarkerGraphOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public boolean hasBaseOptions() {
                return ((PoseLandmarkerGraphOptions) this.instance).hasBaseOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public BaseOptionsProto.BaseOptions getBaseOptions() {
                return ((PoseLandmarkerGraphOptions) this.instance).getBaseOptions();
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).setBaseOptions(baseOptions);
                return this;
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions.Builder builder) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).setBaseOptions(builder.build());
                return this;
            }

            public Builder mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).mergeBaseOptions(baseOptions);
                return this;
            }

            public Builder clearBaseOptions() {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).clearBaseOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public boolean hasPoseDetectorGraphOptions() {
                return ((PoseLandmarkerGraphOptions) this.instance).hasPoseDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions getPoseDetectorGraphOptions() {
                return ((PoseLandmarkerGraphOptions) this.instance).getPoseDetectorGraphOptions();
            }

            public Builder setPoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).setPoseDetectorGraphOptions(poseDetectorGraphOptions);
                return this;
            }

            public Builder setPoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).setPoseDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergePoseDetectorGraphOptions(PoseDetectorGraphOptionsProto.PoseDetectorGraphOptions poseDetectorGraphOptions) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).mergePoseDetectorGraphOptions(poseDetectorGraphOptions);
                return this;
            }

            public Builder clearPoseDetectorGraphOptions() {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).clearPoseDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public boolean hasPoseLandmarksDetectorGraphOptions() {
                return ((PoseLandmarkerGraphOptions) this.instance).hasPoseLandmarksDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions getPoseLandmarksDetectorGraphOptions() {
                return ((PoseLandmarkerGraphOptions) this.instance).getPoseLandmarksDetectorGraphOptions();
            }

            public Builder setPoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).setPoseLandmarksDetectorGraphOptions(poseLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder setPoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).setPoseLandmarksDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergePoseLandmarksDetectorGraphOptions(PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions poseLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).mergePoseLandmarksDetectorGraphOptions(poseLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder clearPoseLandmarksDetectorGraphOptions() {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).clearPoseLandmarksDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public boolean hasMinTrackingConfidence() {
                return ((PoseLandmarkerGraphOptions) this.instance).hasMinTrackingConfidence();
            }

            @Override // com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto.PoseLandmarkerGraphOptionsOrBuilder
            public float getMinTrackingConfidence() {
                return ((PoseLandmarkerGraphOptions) this.instance).getMinTrackingConfidence();
            }

            public Builder setMinTrackingConfidence(float f) {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).setMinTrackingConfidence(f);
                return this;
            }

            public Builder clearMinTrackingConfidence() {
                copyOnWrite();
                ((PoseLandmarkerGraphOptions) this.instance).clearMinTrackingConfidence();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new PoseLandmarkerGraphOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001\u0003ဉ\u0002\u0004ခ\u0003", new Object[]{"bitField0_", "baseOptions_", "poseDetectorGraphOptions_", "poseLandmarksDetectorGraphOptions_", "minTrackingConfidence_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<PoseLandmarkerGraphOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (PoseLandmarkerGraphOptions.class) {
                        try {
                            defaultInstanceBasedParser = PARSER;
                            if (defaultInstanceBasedParser == null) {
                                defaultInstanceBasedParser = new GeneratedMessageLite.DefaultInstanceBasedParser(DEFAULT_INSTANCE);
                                PARSER = defaultInstanceBasedParser;
                            }
                        } catch (Throwable th) {
                            throw th;
                        }
                        break;
                    }
                    return defaultInstanceBasedParser;
                case 6:
                    return (byte) 1;
                case 7:
                    return null;
                default:
                    throw new UnsupportedOperationException();
            }
        }

        static {
            PoseLandmarkerGraphOptions poseLandmarkerGraphOptions = new PoseLandmarkerGraphOptions();
            DEFAULT_INSTANCE = poseLandmarkerGraphOptions;
            GeneratedMessageLite.registerDefaultInstance(PoseLandmarkerGraphOptions.class, poseLandmarkerGraphOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, PoseLandmarkerGraphOptions.class);
        }

        public static PoseLandmarkerGraphOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<PoseLandmarkerGraphOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarkerGraphOptionsProto$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke;

        static {
            int[] iArr = new int[GeneratedMessageLite.MethodToInvoke.values().length];
            $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke = iArr;
            try {
                iArr[GeneratedMessageLite.MethodToInvoke.NEW_MUTABLE_INSTANCE.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.NEW_BUILDER.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.BUILD_MESSAGE_INFO.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.GET_DEFAULT_INSTANCE.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.GET_PARSER.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.GET_MEMOIZED_IS_INITIALIZED.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            try {
                $SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[GeneratedMessageLite.MethodToInvoke.SET_MEMOIZED_IS_INITIALIZED.ordinal()] = 7;
            } catch (NoSuchFieldError unused7) {
            }
        }
    }
}
