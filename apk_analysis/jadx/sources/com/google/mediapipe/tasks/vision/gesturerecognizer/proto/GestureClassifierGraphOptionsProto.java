package com.google.mediapipe.tasks.vision.gesturerecognizer.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto;
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
public final class GestureClassifierGraphOptionsProto {

    public interface GestureClassifierGraphOptionsOrBuilder extends MessageLiteOrBuilder {
        BaseOptionsProto.BaseOptions getBaseOptions();

        ClassifierOptionsProto.ClassifierOptions getClassifierOptions();

        boolean hasBaseOptions();

        boolean hasClassifierOptions();
    }

    private GestureClassifierGraphOptionsProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) GestureClassifierGraphOptions.ext);
    }

    public static final class GestureClassifierGraphOptions extends GeneratedMessageLite<GestureClassifierGraphOptions, Builder> implements GestureClassifierGraphOptionsOrBuilder {
        public static final int BASE_OPTIONS_FIELD_NUMBER = 1;
        public static final int CLASSIFIER_OPTIONS_FIELD_NUMBER = 2;
        private static final GestureClassifierGraphOptions DEFAULT_INSTANCE;
        public static final int EXT_FIELD_NUMBER = 478825465;
        private static volatile Parser<GestureClassifierGraphOptions> PARSER;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, GestureClassifierGraphOptions> ext;
        private BaseOptionsProto.BaseOptions baseOptions_;
        private int bitField0_;
        private ClassifierOptionsProto.ClassifierOptions classifierOptions_;

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

        private GestureClassifierGraphOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
        public boolean hasBaseOptions() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
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

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
        public boolean hasClassifierOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
        public ClassifierOptionsProto.ClassifierOptions getClassifierOptions() {
            ClassifierOptionsProto.ClassifierOptions classifierOptions = this.classifierOptions_;
            return classifierOptions == null ? ClassifierOptionsProto.ClassifierOptions.getDefaultInstance() : classifierOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClassifierOptions(ClassifierOptionsProto.ClassifierOptions classifierOptions) {
            classifierOptions.getClass();
            this.classifierOptions_ = classifierOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeClassifierOptions(ClassifierOptionsProto.ClassifierOptions classifierOptions) {
            classifierOptions.getClass();
            ClassifierOptionsProto.ClassifierOptions classifierOptions2 = this.classifierOptions_;
            if (classifierOptions2 != null && classifierOptions2 != ClassifierOptionsProto.ClassifierOptions.getDefaultInstance()) {
                this.classifierOptions_ = ClassifierOptionsProto.ClassifierOptions.newBuilder(this.classifierOptions_).mergeFrom(classifierOptions).buildPartial();
            } else {
                this.classifierOptions_ = classifierOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearClassifierOptions() {
            this.classifierOptions_ = null;
            this.bitField0_ &= -3;
        }

        public static GestureClassifierGraphOptions parseFrom(ByteBuffer byteBuffer) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static GestureClassifierGraphOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static GestureClassifierGraphOptions parseFrom(ByteString byteString) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static GestureClassifierGraphOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static GestureClassifierGraphOptions parseFrom(byte[] bArr) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static GestureClassifierGraphOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static GestureClassifierGraphOptions parseFrom(InputStream inputStream) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static GestureClassifierGraphOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static GestureClassifierGraphOptions parseDelimitedFrom(InputStream inputStream) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static GestureClassifierGraphOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static GestureClassifierGraphOptions parseFrom(CodedInputStream codedInputStream) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static GestureClassifierGraphOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (GestureClassifierGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(GestureClassifierGraphOptions gestureClassifierGraphOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(gestureClassifierGraphOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<GestureClassifierGraphOptions, Builder> implements GestureClassifierGraphOptionsOrBuilder {
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
                super(GestureClassifierGraphOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
            public boolean hasBaseOptions() {
                return ((GestureClassifierGraphOptions) this.instance).hasBaseOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
            public BaseOptionsProto.BaseOptions getBaseOptions() {
                return ((GestureClassifierGraphOptions) this.instance).getBaseOptions();
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).setBaseOptions(baseOptions);
                return this;
            }

            public Builder setBaseOptions(BaseOptionsProto.BaseOptions.Builder builder) {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).setBaseOptions(builder.build());
                return this;
            }

            public Builder mergeBaseOptions(BaseOptionsProto.BaseOptions baseOptions) {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).mergeBaseOptions(baseOptions);
                return this;
            }

            public Builder clearBaseOptions() {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).clearBaseOptions();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
            public boolean hasClassifierOptions() {
                return ((GestureClassifierGraphOptions) this.instance).hasClassifierOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto.GestureClassifierGraphOptionsOrBuilder
            public ClassifierOptionsProto.ClassifierOptions getClassifierOptions() {
                return ((GestureClassifierGraphOptions) this.instance).getClassifierOptions();
            }

            public Builder setClassifierOptions(ClassifierOptionsProto.ClassifierOptions classifierOptions) {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).setClassifierOptions(classifierOptions);
                return this;
            }

            public Builder setClassifierOptions(ClassifierOptionsProto.ClassifierOptions.Builder builder) {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).setClassifierOptions(builder.build());
                return this;
            }

            public Builder mergeClassifierOptions(ClassifierOptionsProto.ClassifierOptions classifierOptions) {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).mergeClassifierOptions(classifierOptions);
                return this;
            }

            public Builder clearClassifierOptions() {
                copyOnWrite();
                ((GestureClassifierGraphOptions) this.instance).clearClassifierOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new GestureClassifierGraphOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001", new Object[]{"bitField0_", "baseOptions_", "classifierOptions_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<GestureClassifierGraphOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (GestureClassifierGraphOptions.class) {
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
            GestureClassifierGraphOptions gestureClassifierGraphOptions = new GestureClassifierGraphOptions();
            DEFAULT_INSTANCE = gestureClassifierGraphOptions;
            GeneratedMessageLite.registerDefaultInstance(GestureClassifierGraphOptions.class, gestureClassifierGraphOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, GestureClassifierGraphOptions.class);
        }

        public static GestureClassifierGraphOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<GestureClassifierGraphOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.gesturerecognizer.proto.GestureClassifierGraphOptionsProto$1, reason: invalid class name */
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
