package com.google.mediapipe.tasks.components.containers.proto;

import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.Internal;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import java.io.InputStream;
import java.nio.ByteBuffer;
import java.util.Collections;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class EmbeddingsProto {

    public interface EmbeddingOrBuilder extends MessageLiteOrBuilder {
        Embedding.EmbeddingCase getEmbeddingCase();

        FloatEmbedding getFloatEmbedding();

        int getHeadIndex();

        String getHeadName();

        ByteString getHeadNameBytes();

        QuantizedEmbedding getQuantizedEmbedding();

        boolean hasFloatEmbedding();

        boolean hasHeadIndex();

        boolean hasHeadName();

        boolean hasQuantizedEmbedding();
    }

    public interface EmbeddingResultOrBuilder extends MessageLiteOrBuilder {
        Embedding getEmbeddings(int i);

        int getEmbeddingsCount();

        List<Embedding> getEmbeddingsList();

        long getTimestampMs();

        boolean hasTimestampMs();
    }

    public interface FloatEmbeddingOrBuilder extends MessageLiteOrBuilder {
        float getValues(int i);

        int getValuesCount();

        List<Float> getValuesList();
    }

    public interface QuantizedEmbeddingOrBuilder extends MessageLiteOrBuilder {
        ByteString getValues();

        boolean hasValues();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private EmbeddingsProto() {
    }

    public static final class FloatEmbedding extends GeneratedMessageLite<FloatEmbedding, Builder> implements FloatEmbeddingOrBuilder {
        private static final FloatEmbedding DEFAULT_INSTANCE;
        private static volatile Parser<FloatEmbedding> PARSER = null;
        public static final int VALUES_FIELD_NUMBER = 1;
        private int valuesMemoizedSerializedSize = -1;
        private Internal.FloatList values_ = GeneratedMessageLite.emptyFloatList();

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

        private FloatEmbedding() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.FloatEmbeddingOrBuilder
        public List<Float> getValuesList() {
            return this.values_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.FloatEmbeddingOrBuilder
        public int getValuesCount() {
            return this.values_.size();
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.FloatEmbeddingOrBuilder
        public float getValues(int i) {
            return this.values_.getFloat(i);
        }

        private void ensureValuesIsMutable() {
            Internal.FloatList floatList = this.values_;
            if (floatList.isModifiable()) {
                return;
            }
            this.values_ = GeneratedMessageLite.mutableCopy(floatList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setValues(int i, float f) {
            ensureValuesIsMutable();
            this.values_.setFloat(i, f);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addValues(float f) {
            ensureValuesIsMutable();
            this.values_.addFloat(f);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllValues(Iterable<? extends Float> iterable) {
            ensureValuesIsMutable();
            AbstractMessageLite.addAll(iterable, this.values_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearValues() {
            this.values_ = GeneratedMessageLite.emptyFloatList();
        }

        public static FloatEmbedding parseFrom(ByteBuffer byteBuffer) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static FloatEmbedding parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static FloatEmbedding parseFrom(ByteString byteString) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static FloatEmbedding parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static FloatEmbedding parseFrom(byte[] bArr) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static FloatEmbedding parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static FloatEmbedding parseFrom(InputStream inputStream) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FloatEmbedding parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FloatEmbedding parseDelimitedFrom(InputStream inputStream) {
            return (FloatEmbedding) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static FloatEmbedding parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FloatEmbedding) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static FloatEmbedding parseFrom(CodedInputStream codedInputStream) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static FloatEmbedding parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (FloatEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(FloatEmbedding floatEmbedding) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(floatEmbedding);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<FloatEmbedding, Builder> implements FloatEmbeddingOrBuilder {
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
                super(FloatEmbedding.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.FloatEmbeddingOrBuilder
            public List<Float> getValuesList() {
                return Collections.unmodifiableList(((FloatEmbedding) this.instance).getValuesList());
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.FloatEmbeddingOrBuilder
            public int getValuesCount() {
                return ((FloatEmbedding) this.instance).getValuesCount();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.FloatEmbeddingOrBuilder
            public float getValues(int i) {
                return ((FloatEmbedding) this.instance).getValues(i);
            }

            public Builder setValues(int i, float f) {
                copyOnWrite();
                ((FloatEmbedding) this.instance).setValues(i, f);
                return this;
            }

            public Builder addValues(float f) {
                copyOnWrite();
                ((FloatEmbedding) this.instance).addValues(f);
                return this;
            }

            public Builder addAllValues(Iterable<? extends Float> iterable) {
                copyOnWrite();
                ((FloatEmbedding) this.instance).addAllValues(iterable);
                return this;
            }

            public Builder clearValues() {
                copyOnWrite();
                ((FloatEmbedding) this.instance).clearValues();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new FloatEmbedding();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001$", new Object[]{"values_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<FloatEmbedding> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (FloatEmbedding.class) {
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
            FloatEmbedding floatEmbedding = new FloatEmbedding();
            DEFAULT_INSTANCE = floatEmbedding;
            GeneratedMessageLite.registerDefaultInstance(FloatEmbedding.class, floatEmbedding);
        }

        public static FloatEmbedding getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<FloatEmbedding> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto$1, reason: invalid class name */
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

    public static final class QuantizedEmbedding extends GeneratedMessageLite<QuantizedEmbedding, Builder> implements QuantizedEmbeddingOrBuilder {
        private static final QuantizedEmbedding DEFAULT_INSTANCE;
        private static volatile Parser<QuantizedEmbedding> PARSER = null;
        public static final int VALUES_FIELD_NUMBER = 1;
        private int bitField0_;
        private ByteString values_ = ByteString.EMPTY;

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

        private QuantizedEmbedding() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.QuantizedEmbeddingOrBuilder
        public boolean hasValues() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.QuantizedEmbeddingOrBuilder
        public ByteString getValues() {
            return this.values_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setValues(ByteString byteString) {
            byteString.getClass();
            this.bitField0_ |= 1;
            this.values_ = byteString;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearValues() {
            this.bitField0_ &= -2;
            this.values_ = getDefaultInstance().getValues();
        }

        public static QuantizedEmbedding parseFrom(ByteBuffer byteBuffer) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static QuantizedEmbedding parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static QuantizedEmbedding parseFrom(ByteString byteString) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static QuantizedEmbedding parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static QuantizedEmbedding parseFrom(byte[] bArr) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static QuantizedEmbedding parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static QuantizedEmbedding parseFrom(InputStream inputStream) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static QuantizedEmbedding parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static QuantizedEmbedding parseDelimitedFrom(InputStream inputStream) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static QuantizedEmbedding parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static QuantizedEmbedding parseFrom(CodedInputStream codedInputStream) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static QuantizedEmbedding parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (QuantizedEmbedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(QuantizedEmbedding quantizedEmbedding) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(quantizedEmbedding);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<QuantizedEmbedding, Builder> implements QuantizedEmbeddingOrBuilder {
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
                super(QuantizedEmbedding.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.QuantizedEmbeddingOrBuilder
            public boolean hasValues() {
                return ((QuantizedEmbedding) this.instance).hasValues();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.QuantizedEmbeddingOrBuilder
            public ByteString getValues() {
                return ((QuantizedEmbedding) this.instance).getValues();
            }

            public Builder setValues(ByteString byteString) {
                copyOnWrite();
                ((QuantizedEmbedding) this.instance).setValues(byteString);
                return this;
            }

            public Builder clearValues() {
                copyOnWrite();
                ((QuantizedEmbedding) this.instance).clearValues();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new QuantizedEmbedding();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0001\u0001\u0001\u0001\u0000\u0000\u0000\u0001ည\u0000", new Object[]{"bitField0_", "values_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<QuantizedEmbedding> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (QuantizedEmbedding.class) {
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
            QuantizedEmbedding quantizedEmbedding = new QuantizedEmbedding();
            DEFAULT_INSTANCE = quantizedEmbedding;
            GeneratedMessageLite.registerDefaultInstance(QuantizedEmbedding.class, quantizedEmbedding);
        }

        public static QuantizedEmbedding getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<QuantizedEmbedding> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class Embedding extends GeneratedMessageLite<Embedding, Builder> implements EmbeddingOrBuilder {
        private static final Embedding DEFAULT_INSTANCE;
        public static final int FLOAT_EMBEDDING_FIELD_NUMBER = 1;
        public static final int HEAD_INDEX_FIELD_NUMBER = 3;
        public static final int HEAD_NAME_FIELD_NUMBER = 4;
        private static volatile Parser<Embedding> PARSER = null;
        public static final int QUANTIZED_EMBEDDING_FIELD_NUMBER = 2;
        private int bitField0_;
        private Object embedding_;
        private int headIndex_;
        private int embeddingCase_ = 0;
        private String headName_ = "";

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

        private Embedding() {
        }

        public enum EmbeddingCase {
            FLOAT_EMBEDDING(1),
            QUANTIZED_EMBEDDING(2),
            EMBEDDING_NOT_SET(0);

            private final int value;

            EmbeddingCase(int i) {
                this.value = i;
            }

            @Deprecated
            public static EmbeddingCase valueOf(int i) {
                return forNumber(i);
            }

            public static EmbeddingCase forNumber(int i) {
                if (i == 0) {
                    return EMBEDDING_NOT_SET;
                }
                if (i == 1) {
                    return FLOAT_EMBEDDING;
                }
                if (i != 2) {
                    return null;
                }
                return QUANTIZED_EMBEDDING;
            }

            public int getNumber() {
                return this.value;
            }
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public EmbeddingCase getEmbeddingCase() {
            return EmbeddingCase.forNumber(this.embeddingCase_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearEmbedding() {
            this.embeddingCase_ = 0;
            this.embedding_ = null;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public boolean hasFloatEmbedding() {
            return this.embeddingCase_ == 1;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public FloatEmbedding getFloatEmbedding() {
            if (this.embeddingCase_ == 1) {
                return (FloatEmbedding) this.embedding_;
            }
            return FloatEmbedding.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFloatEmbedding(FloatEmbedding floatEmbedding) {
            floatEmbedding.getClass();
            this.embedding_ = floatEmbedding;
            this.embeddingCase_ = 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFloatEmbedding(FloatEmbedding floatEmbedding) {
            floatEmbedding.getClass();
            if (this.embeddingCase_ == 1 && this.embedding_ != FloatEmbedding.getDefaultInstance()) {
                this.embedding_ = FloatEmbedding.newBuilder((FloatEmbedding) this.embedding_).mergeFrom(floatEmbedding).buildPartial();
            } else {
                this.embedding_ = floatEmbedding;
            }
            this.embeddingCase_ = 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFloatEmbedding() {
            if (this.embeddingCase_ == 1) {
                this.embeddingCase_ = 0;
                this.embedding_ = null;
            }
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public boolean hasQuantizedEmbedding() {
            return this.embeddingCase_ == 2;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public QuantizedEmbedding getQuantizedEmbedding() {
            if (this.embeddingCase_ == 2) {
                return (QuantizedEmbedding) this.embedding_;
            }
            return QuantizedEmbedding.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setQuantizedEmbedding(QuantizedEmbedding quantizedEmbedding) {
            quantizedEmbedding.getClass();
            this.embedding_ = quantizedEmbedding;
            this.embeddingCase_ = 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeQuantizedEmbedding(QuantizedEmbedding quantizedEmbedding) {
            quantizedEmbedding.getClass();
            if (this.embeddingCase_ == 2 && this.embedding_ != QuantizedEmbedding.getDefaultInstance()) {
                this.embedding_ = QuantizedEmbedding.newBuilder((QuantizedEmbedding) this.embedding_).mergeFrom(quantizedEmbedding).buildPartial();
            } else {
                this.embedding_ = quantizedEmbedding;
            }
            this.embeddingCase_ = 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearQuantizedEmbedding() {
            if (this.embeddingCase_ == 2) {
                this.embeddingCase_ = 0;
                this.embedding_ = null;
            }
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public boolean hasHeadIndex() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public int getHeadIndex() {
            return this.headIndex_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeadIndex(int i) {
            this.bitField0_ |= 1;
            this.headIndex_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHeadIndex() {
            this.bitField0_ &= -2;
            this.headIndex_ = 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public boolean hasHeadName() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public String getHeadName() {
            return this.headName_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
        public ByteString getHeadNameBytes() {
            return ByteString.copyFromUtf8(this.headName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeadName(String str) {
            str.getClass();
            this.bitField0_ |= 2;
            this.headName_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHeadName() {
            this.bitField0_ &= -3;
            this.headName_ = getDefaultInstance().getHeadName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeadNameBytes(ByteString byteString) {
            this.headName_ = byteString.toStringUtf8();
            this.bitField0_ |= 2;
        }

        public static Embedding parseFrom(ByteBuffer byteBuffer) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Embedding parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Embedding parseFrom(ByteString byteString) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Embedding parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Embedding parseFrom(byte[] bArr) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Embedding parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Embedding parseFrom(InputStream inputStream) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Embedding parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Embedding parseDelimitedFrom(InputStream inputStream) {
            return (Embedding) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Embedding parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Embedding) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Embedding parseFrom(CodedInputStream codedInputStream) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Embedding parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Embedding) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Embedding embedding) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(embedding);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Embedding, Builder> implements EmbeddingOrBuilder {
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
                super(Embedding.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public EmbeddingCase getEmbeddingCase() {
                return ((Embedding) this.instance).getEmbeddingCase();
            }

            public Builder clearEmbedding() {
                copyOnWrite();
                ((Embedding) this.instance).clearEmbedding();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public boolean hasFloatEmbedding() {
                return ((Embedding) this.instance).hasFloatEmbedding();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public FloatEmbedding getFloatEmbedding() {
                return ((Embedding) this.instance).getFloatEmbedding();
            }

            public Builder setFloatEmbedding(FloatEmbedding floatEmbedding) {
                copyOnWrite();
                ((Embedding) this.instance).setFloatEmbedding(floatEmbedding);
                return this;
            }

            public Builder setFloatEmbedding(FloatEmbedding.Builder builder) {
                copyOnWrite();
                ((Embedding) this.instance).setFloatEmbedding(builder.build());
                return this;
            }

            public Builder mergeFloatEmbedding(FloatEmbedding floatEmbedding) {
                copyOnWrite();
                ((Embedding) this.instance).mergeFloatEmbedding(floatEmbedding);
                return this;
            }

            public Builder clearFloatEmbedding() {
                copyOnWrite();
                ((Embedding) this.instance).clearFloatEmbedding();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public boolean hasQuantizedEmbedding() {
                return ((Embedding) this.instance).hasQuantizedEmbedding();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public QuantizedEmbedding getQuantizedEmbedding() {
                return ((Embedding) this.instance).getQuantizedEmbedding();
            }

            public Builder setQuantizedEmbedding(QuantizedEmbedding quantizedEmbedding) {
                copyOnWrite();
                ((Embedding) this.instance).setQuantizedEmbedding(quantizedEmbedding);
                return this;
            }

            public Builder setQuantizedEmbedding(QuantizedEmbedding.Builder builder) {
                copyOnWrite();
                ((Embedding) this.instance).setQuantizedEmbedding(builder.build());
                return this;
            }

            public Builder mergeQuantizedEmbedding(QuantizedEmbedding quantizedEmbedding) {
                copyOnWrite();
                ((Embedding) this.instance).mergeQuantizedEmbedding(quantizedEmbedding);
                return this;
            }

            public Builder clearQuantizedEmbedding() {
                copyOnWrite();
                ((Embedding) this.instance).clearQuantizedEmbedding();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public boolean hasHeadIndex() {
                return ((Embedding) this.instance).hasHeadIndex();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public int getHeadIndex() {
                return ((Embedding) this.instance).getHeadIndex();
            }

            public Builder setHeadIndex(int i) {
                copyOnWrite();
                ((Embedding) this.instance).setHeadIndex(i);
                return this;
            }

            public Builder clearHeadIndex() {
                copyOnWrite();
                ((Embedding) this.instance).clearHeadIndex();
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public boolean hasHeadName() {
                return ((Embedding) this.instance).hasHeadName();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public String getHeadName() {
                return ((Embedding) this.instance).getHeadName();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingOrBuilder
            public ByteString getHeadNameBytes() {
                return ((Embedding) this.instance).getHeadNameBytes();
            }

            public Builder setHeadName(String str) {
                copyOnWrite();
                ((Embedding) this.instance).setHeadName(str);
                return this;
            }

            public Builder clearHeadName() {
                copyOnWrite();
                ((Embedding) this.instance).clearHeadName();
                return this;
            }

            public Builder setHeadNameBytes(ByteString byteString) {
                copyOnWrite();
                ((Embedding) this.instance).setHeadNameBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Embedding();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0001\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001<\u0000\u0002<\u0000\u0003င\u0000\u0004ဈ\u0001", new Object[]{"embedding_", "embeddingCase_", "bitField0_", FloatEmbedding.class, QuantizedEmbedding.class, "headIndex_", "headName_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Embedding> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Embedding.class) {
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
            Embedding embedding = new Embedding();
            DEFAULT_INSTANCE = embedding;
            GeneratedMessageLite.registerDefaultInstance(Embedding.class, embedding);
        }

        public static Embedding getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Embedding> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class EmbeddingResult extends GeneratedMessageLite<EmbeddingResult, Builder> implements EmbeddingResultOrBuilder {
        private static final EmbeddingResult DEFAULT_INSTANCE;
        public static final int EMBEDDINGS_FIELD_NUMBER = 1;
        private static volatile Parser<EmbeddingResult> PARSER = null;
        public static final int TIMESTAMP_MS_FIELD_NUMBER = 2;
        private int bitField0_;
        private Internal.ProtobufList<Embedding> embeddings_ = GeneratedMessageLite.emptyProtobufList();
        private long timestampMs_;

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

        private EmbeddingResult() {
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
        public List<Embedding> getEmbeddingsList() {
            return this.embeddings_;
        }

        public List<? extends EmbeddingOrBuilder> getEmbeddingsOrBuilderList() {
            return this.embeddings_;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
        public int getEmbeddingsCount() {
            return this.embeddings_.size();
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
        public Embedding getEmbeddings(int i) {
            return this.embeddings_.get(i);
        }

        public EmbeddingOrBuilder getEmbeddingsOrBuilder(int i) {
            return this.embeddings_.get(i);
        }

        private void ensureEmbeddingsIsMutable() {
            Internal.ProtobufList<Embedding> protobufList = this.embeddings_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.embeddings_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setEmbeddings(int i, Embedding embedding) {
            embedding.getClass();
            ensureEmbeddingsIsMutable();
            this.embeddings_.set(i, embedding);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addEmbeddings(Embedding embedding) {
            embedding.getClass();
            ensureEmbeddingsIsMutable();
            this.embeddings_.add(embedding);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addEmbeddings(int i, Embedding embedding) {
            embedding.getClass();
            ensureEmbeddingsIsMutable();
            this.embeddings_.add(i, embedding);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllEmbeddings(Iterable<? extends Embedding> iterable) {
            ensureEmbeddingsIsMutable();
            AbstractMessageLite.addAll(iterable, this.embeddings_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearEmbeddings() {
            this.embeddings_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeEmbeddings(int i) {
            ensureEmbeddingsIsMutable();
            this.embeddings_.remove(i);
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
        public boolean hasTimestampMs() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
        public long getTimestampMs() {
            return this.timestampMs_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setTimestampMs(long j) {
            this.bitField0_ |= 1;
            this.timestampMs_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearTimestampMs() {
            this.bitField0_ &= -2;
            this.timestampMs_ = 0L;
        }

        public static EmbeddingResult parseFrom(ByteBuffer byteBuffer) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static EmbeddingResult parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static EmbeddingResult parseFrom(ByteString byteString) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static EmbeddingResult parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static EmbeddingResult parseFrom(byte[] bArr) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static EmbeddingResult parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static EmbeddingResult parseFrom(InputStream inputStream) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static EmbeddingResult parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static EmbeddingResult parseDelimitedFrom(InputStream inputStream) {
            return (EmbeddingResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static EmbeddingResult parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (EmbeddingResult) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static EmbeddingResult parseFrom(CodedInputStream codedInputStream) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static EmbeddingResult parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (EmbeddingResult) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(EmbeddingResult embeddingResult) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(embeddingResult);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<EmbeddingResult, Builder> implements EmbeddingResultOrBuilder {
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
                super(EmbeddingResult.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
            public List<Embedding> getEmbeddingsList() {
                return Collections.unmodifiableList(((EmbeddingResult) this.instance).getEmbeddingsList());
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
            public int getEmbeddingsCount() {
                return ((EmbeddingResult) this.instance).getEmbeddingsCount();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
            public Embedding getEmbeddings(int i) {
                return ((EmbeddingResult) this.instance).getEmbeddings(i);
            }

            public Builder setEmbeddings(int i, Embedding embedding) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).setEmbeddings(i, embedding);
                return this;
            }

            public Builder setEmbeddings(int i, Embedding.Builder builder) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).setEmbeddings(i, builder.build());
                return this;
            }

            public Builder addEmbeddings(Embedding embedding) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).addEmbeddings(embedding);
                return this;
            }

            public Builder addEmbeddings(int i, Embedding embedding) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).addEmbeddings(i, embedding);
                return this;
            }

            public Builder addEmbeddings(Embedding.Builder builder) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).addEmbeddings(builder.build());
                return this;
            }

            public Builder addEmbeddings(int i, Embedding.Builder builder) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).addEmbeddings(i, builder.build());
                return this;
            }

            public Builder addAllEmbeddings(Iterable<? extends Embedding> iterable) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).addAllEmbeddings(iterable);
                return this;
            }

            public Builder clearEmbeddings() {
                copyOnWrite();
                ((EmbeddingResult) this.instance).clearEmbeddings();
                return this;
            }

            public Builder removeEmbeddings(int i) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).removeEmbeddings(i);
                return this;
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
            public boolean hasTimestampMs() {
                return ((EmbeddingResult) this.instance).hasTimestampMs();
            }

            @Override // com.google.mediapipe.tasks.components.containers.proto.EmbeddingsProto.EmbeddingResultOrBuilder
            public long getTimestampMs() {
                return ((EmbeddingResult) this.instance).getTimestampMs();
            }

            public Builder setTimestampMs(long j) {
                copyOnWrite();
                ((EmbeddingResult) this.instance).setTimestampMs(j);
                return this;
            }

            public Builder clearTimestampMs() {
                copyOnWrite();
                ((EmbeddingResult) this.instance).clearTimestampMs();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new EmbeddingResult();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0001\u0000\u0001\u001b\u0002ဂ\u0000", new Object[]{"bitField0_", "embeddings_", Embedding.class, "timestampMs_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<EmbeddingResult> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (EmbeddingResult.class) {
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
            EmbeddingResult embeddingResult = new EmbeddingResult();
            DEFAULT_INSTANCE = embeddingResult;
            GeneratedMessageLite.registerDefaultInstance(EmbeddingResult.class, embeddingResult);
        }

        public static EmbeddingResult getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<EmbeddingResult> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
