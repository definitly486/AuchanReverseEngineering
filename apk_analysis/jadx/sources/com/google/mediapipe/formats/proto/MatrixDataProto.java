package com.google.mediapipe.formats.proto;

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
public final class MatrixDataProto {

    public interface MatrixDataOrBuilder extends MessageLiteOrBuilder {
        int getCols();

        MatrixData.Layout getLayout();

        float getPackedData(int i);

        int getPackedDataCount();

        List<Float> getPackedDataList();

        int getRows();

        boolean hasCols();

        boolean hasLayout();

        boolean hasRows();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private MatrixDataProto() {
    }

    public static final class MatrixData extends GeneratedMessageLite<MatrixData, Builder> implements MatrixDataOrBuilder {
        public static final int COLS_FIELD_NUMBER = 2;
        private static final MatrixData DEFAULT_INSTANCE;
        public static final int LAYOUT_FIELD_NUMBER = 4;
        public static final int PACKED_DATA_FIELD_NUMBER = 3;
        private static volatile Parser<MatrixData> PARSER = null;
        public static final int ROWS_FIELD_NUMBER = 1;
        private int bitField0_;
        private int cols_;
        private int layout_;
        private int packedDataMemoizedSerializedSize = -1;
        private Internal.FloatList packedData_ = GeneratedMessageLite.emptyFloatList();
        private int rows_;

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

        private MatrixData() {
        }

        public enum Layout implements Internal.EnumLite {
            COLUMN_MAJOR(0),
            ROW_MAJOR(1);

            public static final int COLUMN_MAJOR_VALUE = 0;
            public static final int ROW_MAJOR_VALUE = 1;
            private static final Internal.EnumLiteMap<Layout> internalValueMap = new Internal.EnumLiteMap<Layout>() { // from class: com.google.mediapipe.formats.proto.MatrixDataProto.MatrixData.Layout.1
                @Override // com.google.protobuf.Internal.EnumLiteMap
                public Layout findValueByNumber(int i) {
                    return Layout.forNumber(i);
                }
            };
            private final int value;

            @Override // com.google.protobuf.Internal.EnumLite
            public final int getNumber() {
                return this.value;
            }

            @Deprecated
            public static Layout valueOf(int i) {
                return forNumber(i);
            }

            public static Layout forNumber(int i) {
                if (i == 0) {
                    return COLUMN_MAJOR;
                }
                if (i != 1) {
                    return null;
                }
                return ROW_MAJOR;
            }

            public static Internal.EnumLiteMap<Layout> internalGetValueMap() {
                return internalValueMap;
            }

            public static Internal.EnumVerifier internalGetVerifier() {
                return LayoutVerifier.INSTANCE;
            }

            private static final class LayoutVerifier implements Internal.EnumVerifier {
                static final Internal.EnumVerifier INSTANCE = new LayoutVerifier();

                private LayoutVerifier() {
                }

                @Override // com.google.protobuf.Internal.EnumVerifier
                public boolean isInRange(int i) {
                    return Layout.forNumber(i) != null;
                }
            }

            Layout(int i) {
                this.value = i;
            }
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public boolean hasRows() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public int getRows() {
            return this.rows_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRows(int i) {
            this.bitField0_ |= 1;
            this.rows_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRows() {
            this.bitField0_ &= -2;
            this.rows_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public boolean hasCols() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public int getCols() {
            return this.cols_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setCols(int i) {
            this.bitField0_ |= 2;
            this.cols_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearCols() {
            this.bitField0_ &= -3;
            this.cols_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public List<Float> getPackedDataList() {
            return this.packedData_;
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public int getPackedDataCount() {
            return this.packedData_.size();
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public float getPackedData(int i) {
            return this.packedData_.getFloat(i);
        }

        private void ensurePackedDataIsMutable() {
            Internal.FloatList floatList = this.packedData_;
            if (floatList.isModifiable()) {
                return;
            }
            this.packedData_ = GeneratedMessageLite.mutableCopy(floatList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPackedData(int i, float f) {
            ensurePackedDataIsMutable();
            this.packedData_.setFloat(i, f);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPackedData(float f) {
            ensurePackedDataIsMutable();
            this.packedData_.addFloat(f);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllPackedData(Iterable<? extends Float> iterable) {
            ensurePackedDataIsMutable();
            AbstractMessageLite.addAll(iterable, this.packedData_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPackedData() {
            this.packedData_ = GeneratedMessageLite.emptyFloatList();
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public boolean hasLayout() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
        public Layout getLayout() {
            Layout layoutForNumber = Layout.forNumber(this.layout_);
            return layoutForNumber == null ? Layout.COLUMN_MAJOR : layoutForNumber;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLayout(Layout layout) {
            this.layout_ = layout.getNumber();
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLayout() {
            this.bitField0_ &= -5;
            this.layout_ = 0;
        }

        public static MatrixData parseFrom(ByteBuffer byteBuffer) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static MatrixData parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static MatrixData parseFrom(ByteString byteString) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static MatrixData parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static MatrixData parseFrom(byte[] bArr) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static MatrixData parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static MatrixData parseFrom(InputStream inputStream) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static MatrixData parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static MatrixData parseDelimitedFrom(InputStream inputStream) {
            return (MatrixData) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static MatrixData parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (MatrixData) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static MatrixData parseFrom(CodedInputStream codedInputStream) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static MatrixData parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (MatrixData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(MatrixData matrixData) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(matrixData);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<MatrixData, Builder> implements MatrixDataOrBuilder {
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
                super(MatrixData.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public boolean hasRows() {
                return ((MatrixData) this.instance).hasRows();
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public int getRows() {
                return ((MatrixData) this.instance).getRows();
            }

            public Builder setRows(int i) {
                copyOnWrite();
                ((MatrixData) this.instance).setRows(i);
                return this;
            }

            public Builder clearRows() {
                copyOnWrite();
                ((MatrixData) this.instance).clearRows();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public boolean hasCols() {
                return ((MatrixData) this.instance).hasCols();
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public int getCols() {
                return ((MatrixData) this.instance).getCols();
            }

            public Builder setCols(int i) {
                copyOnWrite();
                ((MatrixData) this.instance).setCols(i);
                return this;
            }

            public Builder clearCols() {
                copyOnWrite();
                ((MatrixData) this.instance).clearCols();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public List<Float> getPackedDataList() {
                return Collections.unmodifiableList(((MatrixData) this.instance).getPackedDataList());
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public int getPackedDataCount() {
                return ((MatrixData) this.instance).getPackedDataCount();
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public float getPackedData(int i) {
                return ((MatrixData) this.instance).getPackedData(i);
            }

            public Builder setPackedData(int i, float f) {
                copyOnWrite();
                ((MatrixData) this.instance).setPackedData(i, f);
                return this;
            }

            public Builder addPackedData(float f) {
                copyOnWrite();
                ((MatrixData) this.instance).addPackedData(f);
                return this;
            }

            public Builder addAllPackedData(Iterable<? extends Float> iterable) {
                copyOnWrite();
                ((MatrixData) this.instance).addAllPackedData(iterable);
                return this;
            }

            public Builder clearPackedData() {
                copyOnWrite();
                ((MatrixData) this.instance).clearPackedData();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public boolean hasLayout() {
                return ((MatrixData) this.instance).hasLayout();
            }

            @Override // com.google.mediapipe.formats.proto.MatrixDataProto.MatrixDataOrBuilder
            public Layout getLayout() {
                return ((MatrixData) this.instance).getLayout();
            }

            public Builder setLayout(Layout layout) {
                copyOnWrite();
                ((MatrixData) this.instance).setLayout(layout);
                return this;
            }

            public Builder clearLayout() {
                copyOnWrite();
                ((MatrixData) this.instance).clearLayout();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new MatrixData();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0001\u0000\u0001င\u0000\u0002င\u0001\u0003$\u0004᠌\u0002", new Object[]{"bitField0_", "rows_", "cols_", "packedData_", "layout_", Layout.internalGetVerifier()});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<MatrixData> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (MatrixData.class) {
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
            MatrixData matrixData = new MatrixData();
            DEFAULT_INSTANCE = matrixData;
            GeneratedMessageLite.registerDefaultInstance(MatrixData.class, matrixData);
        }

        public static MatrixData getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<MatrixData> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.formats.proto.MatrixDataProto$1, reason: invalid class name */
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
