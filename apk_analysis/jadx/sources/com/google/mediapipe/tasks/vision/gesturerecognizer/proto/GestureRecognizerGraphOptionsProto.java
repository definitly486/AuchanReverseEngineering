package com.google.mediapipe.tasks.vision.gesturerecognizer.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.core.proto.BaseOptionsProto;
import com.google.mediapipe.tasks.vision.handlandmarker.proto.HandLandmarkerGraphOptionsProto;
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
public final class GestureRecognizerGraphOptionsProto {

    public interface GestureRecognizerGraphOptionsOrBuilder extends MessageLiteOrBuilder {
        BaseOptionsProto.BaseOptions getBaseOptions();

        HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions getHandGestureRecognizerGraphOptions();

        HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions getHandLandmarkerGraphOptions();

        boolean hasBaseOptions();

        boolean hasHandGestureRecognizerGraphOptions();

        boolean hasHandLandmarkerGraphOptions();
    }

    private GestureRecognizerGraphOptionsProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) GestureRecognizerGraphOptions.ext);
    }

    public static final class GestureRecognizerGraphOptions extends GeneratedMessageLite<GestureRecognizerGraphOptions, Builder> implements GestureRecognizerGraphOptionsOrBuilder {
        public static final int BASE_OPTIONS_FIELD_NUMBER = 1;
        private static final GestureRecognizerGraphOptions DEFAULT_INSTANCE;
        public static final int EXT_FIELD_NUMBER = 479097054;
        public static final int HAND_GESTURE_RECOGNIZER_GRAPH_OPTIONS_FIELD_NUMBER = 3;
        public static final int HAND_LANDMARKER_GRAPH_OPTIONS_FIELD_NUMBER = 2;
        private static volatile Parser<GestureRecognizerGraphOptions> PARSER;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, GestureRecognizerGraphOptions> ext;
        private BaseOptionsProto.BaseOptions baseOptions_;
        private int bitField0_;
        private HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions_;
        private HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions handLandmarkerGraphOptions_;

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

        private GestureRecognizerGraphOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
        public boolean hasBaseOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
        public boolean hasHandLandmarkerGraphOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
        public HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions getHandLandmarkerGraphOptions() {
            HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions handLandmarkerGraphOptions = this.handLandmarkerGraphOptions_;
            return handLandmarkerGraphOptions == null ? HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.getDefaultInstance() : handLandmarkerGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHandLandmarkerGraphOptions(HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions handLandmarkerGraphOptions) {
            handLandmarkerGraphOptions.getClass();
            this.handLandmarkerGraphOptions_ = handLandmarkerGraphOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeHandLandmarkerGraphOptions(HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions handLandmarkerGraphOptions) {
            handLandmarkerGraphOptions.getClass();
            HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions handLandmarkerGraphOptions2 = this.handLandmarkerGraphOptions_;
            if (handLandmarkerGraphOptions2 != null && handLandmarkerGraphOptions2 != HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.getDefaultInstance()) {
                this.handLandmarkerGraphOptions_ = HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.newBuilder(this.handLandmarkerGraphOptions_).mergeFrom(handLandmarkerGraphOptions).buildPartial();
            } else {
                this.handLandmarkerGraphOptions_ = handLandmarkerGraphOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHandLandmarkerGraphOptions() {
            this.handLandmarkerGraphOptions_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
        public boolean hasHandGestureRecognizerGraphOptions() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
        public HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions getHandGestureRecognizerGraphOptions() {
            HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions = this.handGestureRecognizerGraphOptions_;
            return handGestureRecognizerGraphOptions == null ? HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions.getDefaultInstance() : handGestureRecognizerGraphOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHandGestureRecognizerGraphOptions(HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions) {
            handGestureRecognizerGraphOptions.getClass();
            this.handGestureRecognizerGraphOptions_ = handGestureRecognizerGraphOptions;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeHandGestureRecognizerGraphOptions(HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions) {
            handGestureRecognizerGraphOptions.getClass();
            HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions2 = this.handGestureRecognizerGraphOptions_;
            if (handGestureRecognizerGraphOptions2 != null && handGestureRecognizerGraphOptions2 != HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions.getDefaultInstance()) {
                this.handGestureRecognizerGraphOptions_ = HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions.newBuilder(this.handGestureRecognizerGraphOptions_).mergeFrom(handGestureRecognizerGraphOptions).buildPartial();
            } else {
                this.handGestureRecognizerGraphOptions_ = handGestureRecognizerGraphOptions;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHandGestureRecognizerGraphOptions() {
            this.handGestureRecognizerGraphOptions_ = null;
            this.bitField0_ &= -5;
        }

        public static GestureRecognizerGraphOptions parseFrom(ByteBuffer byteBuffer) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static GestureRecognizerGraphOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static GestureRecognizerGraphOptions parseFrom(ByteString byteString) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static GestureRecognizerGraphOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static GestureRecognizerGraphOptions parseFrom(byte[] bArr) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static GestureRecognizerGraphOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static GestureRecognizerGraphOptions parseFrom(InputStream inputStream) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static GestureRecognizerGraphOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static GestureRecognizerGraphOptions parseDelimitedFrom(InputStream inputStream) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static GestureRecognizerGraphOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static GestureRecognizerGraphOptions parseFrom(CodedInputStream codedInputStream) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static GestureRecognizerGraphOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureRecognizerGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(GestureRecognizerGraphOptions gestureRecognizerGraphOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(gestureRecognizerGraphOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<GestureRecognizerGraphOptions, Builder> implements GestureRecognizerGraphOptionsOrBuilder {
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
                super(GestureRecognizerGraphOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
            public boolean hasBaseOptions() {
                return ((GestureRecognizerGraphOptions) this.instance).hasBaseOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
            public BaseOptionsProto.BaseOptions getBaseOptions() {
                return ((GestureRecognizerGraphOptions) this.instance).getBaseOptions();
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).setBaseOptions(baseOptions);
                return this;
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions.Builder builder) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).setBaseOptions(builder.build());
                return this;
            }

            public Builder mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).mergeBaseOptions(baseOptions);
                return this;
            }

            public Builder clearBaseOptions() {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).clearBaseOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
            public boolean hasHandLandmarkerGraphOptions() {
                return ((GestureRecognizerGraphOptions) this.instance).hasHandLandmarkerGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
            public HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions getHandLandmarkerGraphOptions() {
                return ((GestureRecognizerGraphOptions) this.instance).getHandLandmarkerGraphOptions();
            }

            public Builder setHandLandmarkerGraphOptions(HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions handLandmarkerGraphOptions) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).setHandLandmarkerGraphOptions(handLandmarkerGraphOptions);
                return this;
            }

            public Builder setHandLandmarkerGraphOptions(HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions.Builder builder) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).setHandLandmarkerGraphOptions(builder.build());
                return this;
            }

            public Builder mergeHandLandmarkerGraphOptions(HandLandmarkerGraphOptionsProto.HandLandmarkerGraphOptions handLandmarkerGraphOptions) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).mergeHandLandmarkerGraphOptions(handLandmarkerGraphOptions);
                return this;
            }

            public Builder clearHandLandmarkerGraphOptions() {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).clearHandLandmarkerGraphOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
            public boolean hasHandGestureRecognizerGraphOptions() {
                return ((GestureRecognizerGraphOptions) this.instance).hasHandGestureRecognizerGraphOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto.GestureRecognizerGraphOptionsOrBuilder
            public HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions getHandGestureRecognizerGraphOptions() {
                return ((GestureRecognizerGraphOptions) this.instance).getHandGestureRecognizerGraphOptions();
            }

            public Builder setHandGestureRecognizerGraphOptions(HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).setHandGestureRecognizerGraphOptions(handGestureRecognizerGraphOptions);
                return this;
            }

            public Builder setHandGestureRecognizerGraphOptions(HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions.Builder builder) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).setHandGestureRecognizerGraphOptions(builder.build());
                return this;
            }

            public Builder mergeHandGestureRecognizerGraphOptions(HandGestureRecognizerGraphOptionsProto.HandGestureRecognizerGraphOptions handGestureRecognizerGraphOptions) {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).mergeHandGestureRecognizerGraphOptions(handGestureRecognizerGraphOptions);
                return this;
            }

            public Builder clearHandGestureRecognizerGraphOptions() {
                copyOnWrite();
                ((GestureRecognizerGraphOptions) this.instance).clearHandGestureRecognizerGraphOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new GestureRecognizerGraphOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001\u0003ဉ\u0002", new Object[]{"bitField0_", "baseOptions_", "handLandmarkerGraphOptions_", "handGestureRecognizerGraphOptions_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<GestureRecognizerGraphOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (GestureRecognizerGraphOptions.class) {
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
            GestureRecognizerGraphOptions gestureRecognizerGraphOptions = new GestureRecognizerGraphOptions();
            DEFAULT_INSTANCE = gestureRecognizerGraphOptions;
            GeneratedMessageLite.registerDefaultInstance(GestureRecognizerGraphOptions.class, gestureRecognizerGraphOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, GestureRecognizerGraphOptions.class);
        }

        public static GestureRecognizerGraphOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<GestureRecognizerGraphOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureRecognizerGraphOptionsProto$1, reason: invalid class name */
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
