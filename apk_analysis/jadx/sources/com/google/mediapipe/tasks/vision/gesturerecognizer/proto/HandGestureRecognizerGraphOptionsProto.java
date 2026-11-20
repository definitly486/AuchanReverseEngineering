package com.google.mediapipe.tasks.vision.gesturerecognizer.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
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
public final class HandGestureRecognizerGraphOptionsProto {

    public interface HandGestureRecognizerGraphOptionsOrBuilder extends MessageLiteOrBuilder {
        BaseOptionsProto.BaseOptions getBaseOptions();

        GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions getCannedGestureClassifierGraphOptions();

        GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions getCustomGestureClassifierGraphOptions();

        GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions getGestureEmbedderGraphOptions();

        boolean hasBaseOptions();

        boolean hasCannedGestureClassifierGraphOptions();

        boolean hasCustomGestureClassifierGraphOptions();

        boolean hasGestureEmbedderGraphOptions();
    }

    private HandGestureRecognizerGraphOptionsProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) HandGestureRecognizerGraphOptions.ext);
    }

    public static final class HandGestureRecognizerGraphOptions extends GeneratedMessageLite<HandGestureRecognizerGraphOptions, Builder> implements HandGestureRecognizerGraphOptionsOrBuilder {
        public static final int BASE_OPTIONS_FIELD_NUMBER = 1;
        public static final int CANNED_GESTURE_CLASSIFIER_GRAPH_OPTIONS_FIELD_NUMBER = 3;
        public static final int CUSTOM_GESTURE_CLASSIFIER_GRAPH_OPTIONS_FIELD_NUMBER = 4;
        private static final HandGestureRecognizerGraphOptions DEFAULT_INSTANCE;
        public static final int EXT_FIELD_NUMBER = 463370452;
        public static final int GESTURE_EMBEDDER_GRAPH_OPTIONS_FIELD_NUMBER = 2;
        private static volatile Parser<HandGestureRecognizerGraphOptions> PARSER;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, HandGestureRecognizerGraphOptions> ext;
        private BaseOptionsProto.BaseOptions baseOptions_;
        private int bitField0_;
        private GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions cannedGestureClassifierGraphOptions_;
        private GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions customGestureClassifierGraphOptions_;
        private GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions gestureEmbedderGraphOptions_;

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

        private HandGestureRecognizerGraphOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
        public boolean hasBaseOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
        public boolean hasGestureEmbedderGraphOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
        public GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions getGestureEmbedderGraphOptions() {
            GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions gestureEmbedderGraphOptions = this.gestureEmbedderGraphOptions_;
            return gestureEmbedderGraphOptions == null ? GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions.getDefaultInstance() : gestureEmbedderGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setGestureEmbedderGraphOptions(GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions gestureEmbedderGraphOptions) {
            gestureEmbedderGraphOptions.getClass();
            this.gestureEmbedderGraphOptions_ = gestureEmbedderGraphOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeGestureEmbedderGraphOptions(GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions gestureEmbedderGraphOptions) {
            gestureEmbedderGraphOptions.getClass();
            GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions gestureEmbedderGraphOptions2 = this.gestureEmbedderGraphOptions_;
            if (gestureEmbedderGraphOptions2 != null && gestureEmbedderGraphOptions2 != GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions.getDefaultInstance()) {
                this.gestureEmbedderGraphOptions_ = GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions.newBuilder(this.gestureEmbedderGraphOptions_).mergeFrom(gestureEmbedderGraphOptions).buildPartial();
            } else {
                this.gestureEmbedderGraphOptions_ = gestureEmbedderGraphOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearGestureEmbedderGraphOptions() {
            this.gestureEmbedderGraphOptions_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
        public boolean hasCannedGestureClassifierGraphOptions() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
        public GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions getCannedGestureClassifierGraphOptions() {
            GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions = this.cannedGestureClassifierGraphOptions_;
            return gestureClassifierGraphOptions == null ? GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.getDefaultInstance() : gestureClassifierGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCannedGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
            gestureClassifierGraphOptions.getClass();
            this.cannedGestureClassifierGraphOptions_ = gestureClassifierGraphOptions;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeCannedGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
            gestureClassifierGraphOptions.getClass();
            GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions2 = this.cannedGestureClassifierGraphOptions_;
            if (gestureClassifierGraphOptions2 != null && gestureClassifierGraphOptions2 != GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.getDefaultInstance()) {
                this.cannedGestureClassifierGraphOptions_ = GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.newBuilder(this.cannedGestureClassifierGraphOptions_).mergeFrom(gestureClassifierGraphOptions).buildPartial();
            } else {
                this.cannedGestureClassifierGraphOptions_ = gestureClassifierGraphOptions;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCannedGestureClassifierGraphOptions() {
            this.cannedGestureClassifierGraphOptions_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
        public boolean hasCustomGestureClassifierGraphOptions() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
        public GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions getCustomGestureClassifierGraphOptions() {
            GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions = this.customGestureClassifierGraphOptions_;
            return gestureClassifierGraphOptions == null ? GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.getDefaultInstance() : gestureClassifierGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCustomGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
            gestureClassifierGraphOptions.getClass();
            this.customGestureClassifierGraphOptions_ = gestureClassifierGraphOptions;
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeCustomGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
            gestureClassifierGraphOptions.getClass();
            GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions2 = this.customGestureClassifierGraphOptions_;
            if (gestureClassifierGraphOptions2 != null && gestureClassifierGraphOptions2 != GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.getDefaultInstance()) {
                this.customGestureClassifierGraphOptions_ = GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.newBuilder(this.customGestureClassifierGraphOptions_).mergeFrom(gestureClassifierGraphOptions).buildPartial();
            } else {
                this.customGestureClassifierGraphOptions_ = gestureClassifierGraphOptions;
            }
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCustomGestureClassifierGraphOptions() {
            this.customGestureClassifierGraphOptions_ = null;
            this.bitField0_ &= -9;
        }

        public static HandGestureRecognizerGraphOptions parseFrom(ByteBuffer byteBuffer) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(ByteString byteString) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(byte[] bArr) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(InputStream inputStream) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static HandGestureRecognizerGraphOptions parseDelimitedFrom(InputStream inputStream) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static HandGestureRecognizerGraphOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(CodedInputStream codedInputStream) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static HandGestureRecognizerGraphOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (HandGestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(handGestureRecognizerGraphOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<HandGestureRecognizerGraphOptions, Builder> implements HandGestureRecognizerGraphOptionsOrBuilder {
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
                super(HandGestureRecognizerGraphOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public boolean hasBaseOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).hasBaseOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public BaseOptionsProto.BaseOptions getBaseOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).getBaseOptions();
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setBaseOptions(baseOptions);
                return this;
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions.Builder builder) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setBaseOptions(builder.build());
                return this;
            }

            public Builder mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).mergeBaseOptions(baseOptions);
                return this;
            }

            public Builder clearBaseOptions() {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).clearBaseOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public boolean hasGestureEmbedderGraphOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).hasGestureEmbedderGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions getGestureEmbedderGraphOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).getGestureEmbedderGraphOptions();
            }

            public Builder setGestureEmbedderGraphOptions(GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions gestureEmbedderGraphOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setGestureEmbedderGraphOptions(gestureEmbedderGraphOptions);
                return this;
            }

            public Builder setGestureEmbedderGraphOptions(GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions.Builder builder) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setGestureEmbedderGraphOptions(builder.build());
                return this;
            }

            public Builder mergeGestureEmbedderGraphOptions(GestureEmbedderGraphOptionsProto.GestureEmbedderGraphOptions gestureEmbedderGraphOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).mergeGestureEmbedderGraphOptions(gestureEmbedderGraphOptions);
                return this;
            }

            public Builder clearGestureEmbedderGraphOptions() {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).clearGestureEmbedderGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public boolean hasCannedGestureClassifierGraphOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).hasCannedGestureClassifierGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions getCannedGestureClassifierGraphOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).getCannedGestureClassifierGraphOptions();
            }

            public Builder setCannedGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setCannedGestureClassifierGraphOptions(gestureClassifierGraphOptions);
                return this;
            }

            public Builder setCannedGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.Builder builder) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setCannedGestureClassifierGraphOptions(builder.build());
                return this;
            }

            public Builder mergeCannedGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).mergeCannedGestureClassifierGraphOptions(gestureClassifierGraphOptions);
                return this;
            }

            public Builder clearCannedGestureClassifierGraphOptions() {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).clearCannedGestureClassifierGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public boolean hasCustomGestureClassifierGraphOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).hasCustomGestureClassifierGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptionsOrBuilder
            public GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions getCustomGestureClassifierGraphOptions() {
                return ((HandGestureRecognizerGraphOptions) this.instance).getCustomGestureClassifierGraphOptions();
            }

            public Builder setCustomGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setCustomGestureClassifierGraphOptions(gestureClassifierGraphOptions);
                return this;
            }

            public Builder setCustomGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions.Builder builder) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).setCustomGestureClassifierGraphOptions(builder.build());
                return this;
            }

            public Builder mergeCustomGestureClassifierGraphOptions(GestureClassifierGraphOptionsProto.GestureClassifierGraphOptions gestureClassifierGraphOptions) {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).mergeCustomGestureClassifierGraphOptions(gestureClassifierGraphOptions);
                return this;
            }

            public Builder clearCustomGestureClassifierGraphOptions() {
                copyOnWrite();
                ((HandGestureRecognizerGraphOptions) this.instance).clearCustomGestureClassifierGraphOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new HandGestureRecognizerGraphOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001\u0003ဉ\u0002\u0004ဉ\u0003", new Object[]{"bitField0_", "baseOptions_", "gestureEmbedderGraphOptions_", "cannedGestureClassifierGraphOptions_", "customGestureClassifierGraphOptions_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<HandGestureRecognizerGraphOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (HandGestureRecognizerGraphOptions.class) {
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
            HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions = new HandGestureRecognizerGraphOptions();
            DEFAULT_INSTANCE = handGestureRecognizerGraphOptions;
            GeneratedMessageLite.registerDefaultInstance(HandGestureRecognizerGraphOptions.class, handGestureRecognizerGraphOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, HandGestureRecognizerGraphOptions.class);
        }

        public static HandGestureRecognizerGraphOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<HandGestureRecognizerGraphOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.gesturerecognizer.proto.HandGestureRecognizerGraphOptionsProto$1, reason: invalid class name */
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
