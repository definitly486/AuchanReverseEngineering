package com.google.mediapipe.util.proto;

import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.MapEntryLite;
import com.google.protobuf.MapFieldLite;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import com.google.protobuf.WireFormat;
import java.io.InputStream;
import java.nio.ByteBuffer;
import java.util.Collections;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class ColorProto {

    public interface ColorMapOrBuilder extends MessageLiteOrBuilder {
        boolean containsLabelToColor(String str);

        @Deprecated
        Map<String, Color> getLabelToColor();

        int getLabelToColorCount();

        Map<String, Color> getLabelToColorMap();

        Color getLabelToColorOrDefault(String str, Color color);

        Color getLabelToColorOrThrow(String str);
    }

    public interface ColorOrBuilder extends MessageLiteOrBuilder {
        int getB();

        int getG();

        int getR();

        boolean hasB();

        boolean hasG();

        boolean hasR();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private ColorProto() {
    }

    public static final class Color extends GeneratedMessageLite<Color, Builder> implements ColorOrBuilder {
        public static final int B_FIELD_NUMBER = 3;
        private static final Color DEFAULT_INSTANCE;
        public static final int G_FIELD_NUMBER = 2;
        private static volatile Parser<Color> PARSER = null;
        public static final int R_FIELD_NUMBER = 1;
        private int b_;
        private int bitField0_;
        private int g_;
        private int r_;

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

        private Color() {
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
        public boolean hasR() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
        public int getR() {
            return this.r_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setR(int i) {
            this.bitField0_ |= 1;
            this.r_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearR() {
            this.bitField0_ &= -2;
            this.r_ = 0;
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
        public boolean hasG() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
        public int getG() {
            return this.g_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setG(int i) {
            this.bitField0_ |= 2;
            this.g_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearG() {
            this.bitField0_ &= -3;
            this.g_ = 0;
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
        public boolean hasB() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
        public int getB() {
            return this.b_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setB(int i) {
            this.bitField0_ |= 4;
            this.b_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearB() {
            this.bitField0_ &= -5;
            this.b_ = 0;
        }

        public static Color parseFrom(ByteBuffer byteBuffer) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Color parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Color parseFrom(ByteString byteString) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Color parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Color parseFrom(byte[] bArr) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Color parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Color parseFrom(InputStream inputStream) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Color parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Color parseDelimitedFrom(InputStream inputStream) {
            return (Color) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Color parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Color) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Color parseFrom(CodedInputStream codedInputStream) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Color parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Color) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Color color) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(color);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Color, Builder> implements ColorOrBuilder {
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
                super(Color.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
            public boolean hasR() {
                return ((Color) this.instance).hasR();
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
            public int getR() {
                return ((Color) this.instance).getR();
            }

            public Builder setR(int i) {
                copyOnWrite();
                ((Color) this.instance).setR(i);
                return this;
            }

            public Builder clearR() {
                copyOnWrite();
                ((Color) this.instance).clearR();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
            public boolean hasG() {
                return ((Color) this.instance).hasG();
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
            public int getG() {
                return ((Color) this.instance).getG();
            }

            public Builder setG(int i) {
                copyOnWrite();
                ((Color) this.instance).setG(i);
                return this;
            }

            public Builder clearG() {
                copyOnWrite();
                ((Color) this.instance).clearG();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
            public boolean hasB() {
                return ((Color) this.instance).hasB();
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorOrBuilder
            public int getB() {
                return ((Color) this.instance).getB();
            }

            public Builder setB(int i) {
                copyOnWrite();
                ((Color) this.instance).setB(i);
                return this;
            }

            public Builder clearB() {
                copyOnWrite();
                ((Color) this.instance).clearB();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Color();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001င\u0000\u0002င\u0001\u0003င\u0002", new Object[]{"bitField0_", "r_", "g_", "b_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Color> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Color.class) {
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
            Color color = new Color();
            DEFAULT_INSTANCE = color;
            GeneratedMessageLite.registerDefaultInstance(Color.class, color);
        }

        public static Color getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Color> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.util.proto.ColorProto$1, reason: invalid class name */
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

    public static final class ColorMap extends GeneratedMessageLite<ColorMap, Builder> implements ColorMapOrBuilder {
        private static final ColorMap DEFAULT_INSTANCE;
        public static final int LABEL_TO_COLOR_FIELD_NUMBER = 1;
        private static volatile Parser<ColorMap> PARSER;
        private MapFieldLite<String, Color> labelToColor_ = MapFieldLite.emptyMapField();

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

        private ColorMap() {
        }

        private static final class LabelToColorDefaultEntryHolder {
            static final MapEntryLite<String, Color> defaultEntry = MapEntryLite.newDefaultInstance(WireFormat.FieldType.STRING, "", WireFormat.FieldType.MESSAGE, Color.getDefaultInstance());

            private LabelToColorDefaultEntryHolder() {
            }
        }

        private MapFieldLite<String, Color> internalGetLabelToColor() {
            return this.labelToColor_;
        }

        private MapFieldLite<String, Color> internalGetMutableLabelToColor() {
            if (!this.labelToColor_.isMutable()) {
                this.labelToColor_ = this.labelToColor_.mutableCopy();
            }
            return this.labelToColor_;
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
        public int getLabelToColorCount() {
            return internalGetLabelToColor().size();
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
        public boolean containsLabelToColor(String str) {
            str.getClass();
            return internalGetLabelToColor().containsKey(str);
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
        @Deprecated
        public Map<String, Color> getLabelToColor() {
            return getLabelToColorMap();
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
        public Map<String, Color> getLabelToColorMap() {
            return Collections.unmodifiableMap(internalGetLabelToColor());
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
        public Color getLabelToColorOrDefault(String str, Color color) {
            str.getClass();
            MapFieldLite<String, Color> mapFieldLiteInternalGetLabelToColor = internalGetLabelToColor();
            return mapFieldLiteInternalGetLabelToColor.containsKey(str) ? mapFieldLiteInternalGetLabelToColor.get(str) : color;
        }

        @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
        public Color getLabelToColorOrThrow(String str) {
            str.getClass();
            MapFieldLite<String, Color> mapFieldLiteInternalGetLabelToColor = internalGetLabelToColor();
            if (!mapFieldLiteInternalGetLabelToColor.containsKey(str)) {
                throw new IllegalArgumentException();
            }
            return mapFieldLiteInternalGetLabelToColor.get(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public Map<String, Color> getMutableLabelToColorMap() {
            return internalGetMutableLabelToColor();
        }

        public static ColorMap parseFrom(ByteBuffer byteBuffer) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ColorMap parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ColorMap parseFrom(ByteString byteString) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ColorMap parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ColorMap parseFrom(byte[] bArr) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ColorMap parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ColorMap parseFrom(InputStream inputStream) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ColorMap parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ColorMap parseDelimitedFrom(InputStream inputStream) {
            return (ColorMap) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ColorMap parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ColorMap) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ColorMap parseFrom(CodedInputStream codedInputStream) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ColorMap parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ColorMap) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ColorMap colorMap) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(colorMap);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ColorMap, Builder> implements ColorMapOrBuilder {
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
                super(ColorMap.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
            public int getLabelToColorCount() {
                return ((ColorMap) this.instance).getLabelToColorMap().size();
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
            public boolean containsLabelToColor(String str) {
                str.getClass();
                return ((ColorMap) this.instance).getLabelToColorMap().containsKey(str);
            }

            public Builder clearLabelToColor() {
                copyOnWrite();
                ((ColorMap) this.instance).getMutableLabelToColorMap().clear();
                return this;
            }

            public Builder removeLabelToColor(String str) {
                str.getClass();
                copyOnWrite();
                ((ColorMap) this.instance).getMutableLabelToColorMap().remove(str);
                return this;
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
            @Deprecated
            public Map<String, Color> getLabelToColor() {
                return getLabelToColorMap();
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
            public Map<String, Color> getLabelToColorMap() {
                return Collections.unmodifiableMap(((ColorMap) this.instance).getLabelToColorMap());
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
            public Color getLabelToColorOrDefault(String str, Color color) {
                str.getClass();
                Map<String, Color> labelToColorMap = ((ColorMap) this.instance).getLabelToColorMap();
                return labelToColorMap.containsKey(str) ? labelToColorMap.get(str) : color;
            }

            @Override // com.google.mediapipe.util.proto.ColorProto.ColorMapOrBuilder
            public Color getLabelToColorOrThrow(String str) {
                str.getClass();
                Map<String, Color> labelToColorMap = ((ColorMap) this.instance).getLabelToColorMap();
                if (!labelToColorMap.containsKey(str)) {
                    throw new IllegalArgumentException();
                }
                return labelToColorMap.get(str);
            }

            public Builder putLabelToColor(String str, Color color) {
                str.getClass();
                color.getClass();
                copyOnWrite();
                ((ColorMap) this.instance).getMutableLabelToColorMap().put(str, color);
                return this;
            }

            public Builder putAllLabelToColor(Map<String, Color> map) {
                copyOnWrite();
                ((ColorMap) this.instance).getMutableLabelToColorMap().putAll(map);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ColorMap();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0001\u0000\u0000\u00012", new Object[]{"labelToColor_", LabelToColorDefaultEntryHolder.defaultEntry});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ColorMap> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ColorMap.class) {
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
            ColorMap colorMap = new ColorMap();
            DEFAULT_INSTANCE = colorMap;
            GeneratedMessageLite.registerDefaultInstance(ColorMap.class, colorMap);
        }

        public static ColorMap getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ColorMap> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
