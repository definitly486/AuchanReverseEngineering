package com.google.mediapipe.tasks.vision.facelandmarker.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.mediapipe.tasks.vision.facedetector.proto.FaceDetectorGraphOptionsProto;
import com.google.mediapipe.tasks.vision.facegeometry.proto.FaceGeometryGraphOptionsProto;
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
public final class FaceLandmarkerGraphOptionsProto {

    public interface FaceLandmarkerGraphOptionsOrBuilder extends MessageLiteOrBuilder {
        BaseOptionsProto.BaseOptions getBaseOptions();

        FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions getFaceDetectorGraphOptions();

        FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions getFaceGeometryGraphOptions();

        FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions getFaceLandmarksDetectorGraphOptions();

        float getMinTrackingConfidence();

        boolean hasBaseOptions();

        boolean hasFaceDetectorGraphOptions();

        boolean hasFaceGeometryGraphOptions();

        boolean hasFaceLandmarksDetectorGraphOptions();

        boolean hasMinTrackingConfidence();
    }

    private FaceLandmarkerGraphOptionsProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) FaceLandmarkerGraphOptions.ext);
    }

    public static final class FaceLandmarkerGraphOptions extends GeneratedMessageLite<FaceLandmarkerGraphOptions, Builder> implements FaceLandmarkerGraphOptionsOrBuilder {
        public static final int BASE_OPTIONS_FIELD_NUMBER = 1;
        private static final FaceLandmarkerGraphOptions DEFAULT_INSTANCE;
        public static final int EXT_FIELD_NUMBER = 508968150;
        public static final int FACE_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 2;
        public static final int FACE_GEOMETRY_GRAPH_OPTIONS_FIELD_NUMBER = 5;
        public static final int FACE_LANDMARKS_DETECTOR_GRAPH_OPTIONS_FIELD_NUMBER = 3;
        public static final int MIN_TRACKING_CONFIDENCE_FIELD_NUMBER = 4;
        private static volatile Parser<FaceLandmarkerGraphOptions> PARSER;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, FaceLandmarkerGraphOptions> ext;
        private BaseOptionsProto.BaseOptions baseOptions_;
        private int bitField0_;
        private FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions_;
        private FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions faceGeometryGraphOptions_;
        private FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions_;
        private float minTrackingConfidence_ = 0.5f;

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

        private FaceLandmarkerGraphOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public boolean hasBaseOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public boolean hasFaceDetectorGraphOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions getFaceDetectorGraphOptions() {
            FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions = this.faceDetectorGraphOptions_;
            return faceDetectorGraphOptions == null ? FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.getDefaultInstance() : faceDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
            faceDetectorGraphOptions.getClass();
            this.faceDetectorGraphOptions_ = faceDetectorGraphOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
            faceDetectorGraphOptions.getClass();
            FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions2 = this.faceDetectorGraphOptions_;
            if (faceDetectorGraphOptions2 != null && faceDetectorGraphOptions2 != FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.getDefaultInstance()) {
                this.faceDetectorGraphOptions_ = FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.newBuilder(this.faceDetectorGraphOptions_).mergeFrom(faceDetectorGraphOptions).buildPartial();
            } else {
                this.faceDetectorGraphOptions_ = faceDetectorGraphOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFaceDetectorGraphOptions() {
            this.faceDetectorGraphOptions_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public boolean hasFaceLandmarksDetectorGraphOptions() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions getFaceLandmarksDetectorGraphOptions() {
            FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions = this.faceLandmarksDetectorGraphOptions_;
            return faceLandmarksDetectorGraphOptions == null ? FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.getDefaultInstance() : faceLandmarksDetectorGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
            faceLandmarksDetectorGraphOptions.getClass();
            this.faceLandmarksDetectorGraphOptions_ = faceLandmarksDetectorGraphOptions;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
            faceLandmarksDetectorGraphOptions.getClass();
            FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions2 = this.faceLandmarksDetectorGraphOptions_;
            if (faceLandmarksDetectorGraphOptions2 != null && faceLandmarksDetectorGraphOptions2 != FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.getDefaultInstance()) {
                this.faceLandmarksDetectorGraphOptions_ = FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.newBuilder(this.faceLandmarksDetectorGraphOptions_).mergeFrom(faceLandmarksDetectorGraphOptions).buildPartial();
            } else {
                this.faceLandmarksDetectorGraphOptions_ = faceLandmarksDetectorGraphOptions;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFaceLandmarksDetectorGraphOptions() {
            this.faceLandmarksDetectorGraphOptions_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public boolean hasMinTrackingConfidence() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public boolean hasFaceGeometryGraphOptions() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
        public FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions getFaceGeometryGraphOptions() {
            FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions faceGeometryGraphOptions = this.faceGeometryGraphOptions_;
            return faceGeometryGraphOptions == null ? FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions.getDefaultInstance() : faceGeometryGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFaceGeometryGraphOptions(FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions faceGeometryGraphOptions) {
            faceGeometryGraphOptions.getClass();
            this.faceGeometryGraphOptions_ = faceGeometryGraphOptions;
            this.bitField0_ |= 16;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFaceGeometryGraphOptions(FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions faceGeometryGraphOptions) {
            faceGeometryGraphOptions.getClass();
            FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions faceGeometryGraphOptions2 = this.faceGeometryGraphOptions_;
            if (faceGeometryGraphOptions2 != null && faceGeometryGraphOptions2 != FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions.getDefaultInstance()) {
                this.faceGeometryGraphOptions_ = FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions.newBuilder(this.faceGeometryGraphOptions_).mergeFrom(faceGeometryGraphOptions).buildPartial();
            } else {
                this.faceGeometryGraphOptions_ = faceGeometryGraphOptions;
            }
            this.bitField0_ |= 16;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFaceGeometryGraphOptions() {
            this.faceGeometryGraphOptions_ = null;
            this.bitField0_ &= -17;
        }

        public static FaceLandmarkerGraphOptions parseFrom(ByteBuffer byteBuffer) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static FaceLandmarkerGraphOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static FaceLandmarkerGraphOptions parseFrom(ByteString byteString) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static FaceLandmarkerGraphOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static FaceLandmarkerGraphOptions parseFrom(byte[] bArr) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static FaceLandmarkerGraphOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static FaceLandmarkerGraphOptions parseFrom(InputStream inputStream) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FaceLandmarkerGraphOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FaceLandmarkerGraphOptions parseDelimitedFrom(InputStream inputStream) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FaceLandmarkerGraphOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FaceLandmarkerGraphOptions parseFrom(CodedInputStream codedInputStream) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static FaceLandmarkerGraphOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FaceLandmarkerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(FaceLandmarkerGraphOptions faceLandmarkerGraphOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(faceLandmarkerGraphOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<FaceLandmarkerGraphOptions, Builder> implements FaceLandmarkerGraphOptionsOrBuilder {
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
                super(FaceLandmarkerGraphOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public boolean hasBaseOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).hasBaseOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public BaseOptionsProto.BaseOptions getBaseOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).getBaseOptions();
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setBaseOptions(baseOptions);
                return this;
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions.Builder builder) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setBaseOptions(builder.build());
                return this;
            }

            public Builder mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).mergeBaseOptions(baseOptions);
                return this;
            }

            public Builder clearBaseOptions() {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).clearBaseOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public boolean hasFaceDetectorGraphOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).hasFaceDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions getFaceDetectorGraphOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).getFaceDetectorGraphOptions();
            }

            public Builder setFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setFaceDetectorGraphOptions(faceDetectorGraphOptions);
                return this;
            }

            public Builder setFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setFaceDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergeFaceDetectorGraphOptions(FaceDetectorGraphOptionsProto.FaceDetectorGraphOptions faceDetectorGraphOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).mergeFaceDetectorGraphOptions(faceDetectorGraphOptions);
                return this;
            }

            public Builder clearFaceDetectorGraphOptions() {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).clearFaceDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public boolean hasFaceLandmarksDetectorGraphOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).hasFaceLandmarksDetectorGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions getFaceLandmarksDetectorGraphOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).getFaceLandmarksDetectorGraphOptions();
            }

            public Builder setFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setFaceLandmarksDetectorGraphOptions(faceLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder setFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.Builder builder) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setFaceLandmarksDetectorGraphOptions(builder.build());
                return this;
            }

            public Builder mergeFaceLandmarksDetectorGraphOptions(FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions faceLandmarksDetectorGraphOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).mergeFaceLandmarksDetectorGraphOptions(faceLandmarksDetectorGraphOptions);
                return this;
            }

            public Builder clearFaceLandmarksDetectorGraphOptions() {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).clearFaceLandmarksDetectorGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public boolean hasMinTrackingConfidence() {
                return ((FaceLandmarkerGraphOptions) this.instance).hasMinTrackingConfidence();
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public float getMinTrackingConfidence() {
                return ((FaceLandmarkerGraphOptions) this.instance).getMinTrackingConfidence();
            }

            public Builder setMinTrackingConfidence(float f) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setMinTrackingConfidence(f);
                return this;
            }

            public Builder clearMinTrackingConfidence() {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).clearMinTrackingConfidence();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public boolean hasFaceGeometryGraphOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).hasFaceGeometryGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto.FaceLandmarkerGraphOptionsOrBuilder
            public FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions getFaceGeometryGraphOptions() {
                return ((FaceLandmarkerGraphOptions) this.instance).getFaceGeometryGraphOptions();
            }

            public Builder setFaceGeometryGraphOptions(FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions faceGeometryGraphOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setFaceGeometryGraphOptions(faceGeometryGraphOptions);
                return this;
            }

            public Builder setFaceGeometryGraphOptions(FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions.Builder builder) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).setFaceGeometryGraphOptions(builder.build());
                return this;
            }

            public Builder mergeFaceGeometryGraphOptions(FaceGeometryGraphOptionsProto.FaceGeometryGraphOptions faceGeometryGraphOptions) {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).mergeFaceGeometryGraphOptions(faceGeometryGraphOptions);
                return this;
            }

            public Builder clearFaceGeometryGraphOptions() {
                copyOnWrite();
                ((FaceLandmarkerGraphOptions) this.instance).clearFaceGeometryGraphOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new FaceLandmarkerGraphOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0005\u0000\u0001\u0001\u0005\u0005\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001\u0003ဉ\u0002\u0004ခ\u0003\u0005ဉ\u0004", new Object[]{"bitField0_", "baseOptions_", "faceDetectorGraphOptions_", "faceLandmarksDetectorGraphOptions_", "minTrackingConfidence_", "faceGeometryGraphOptions_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<FaceLandmarkerGraphOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (FaceLandmarkerGraphOptions.class) {
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
            FaceLandmarkerGraphOptions faceLandmarkerGraphOptions = new FaceLandmarkerGraphOptions();
            DEFAULT_INSTANCE = faceLandmarkerGraphOptions;
            GeneratedMessageLite.registerDefaultInstance(FaceLandmarkerGraphOptions.class, faceLandmarkerGraphOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, FaceLandmarkerGraphOptions.class);
        }

        public static FaceLandmarkerGraphOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<FaceLandmarkerGraphOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarkerGraphOptionsProto$1, reason: invalid class name */
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
