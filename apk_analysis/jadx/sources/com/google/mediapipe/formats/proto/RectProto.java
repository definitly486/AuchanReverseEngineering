package com.google.mediapipe.formats.proto;

import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.MessageLite;
import com.google.protobuf.MessageLiteOrBuilder;
import com.google.protobuf.Parser;
import java.io.InputStream;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes3.dex */
public final class RectProto {

    public interface NormalizedRectOrBuilder extends MessageLiteOrBuilder {
        float getHeight();

        long getRectId();

        float getRotation();

        float getWidth();

        float getXCenter();

        float getYCenter();

        boolean hasHeight();

        boolean hasRectId();

        boolean hasRotation();

        boolean hasWidth();

        boolean hasXCenter();

        boolean hasYCenter();
    }

    public interface RectOrBuilder extends MessageLiteOrBuilder {
        int getHeight();

        long getRectId();

        float getRotation();

        int getWidth();

        int getXCenter();

        int getYCenter();

        boolean hasHeight();

        boolean hasRectId();

        boolean hasRotation();

        boolean hasWidth();

        boolean hasXCenter();

        boolean hasYCenter();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private RectProto() {
    }

    public static final class Rect extends GeneratedMessageLite<Rect, Builder> implements RectOrBuilder {
        private static final Rect DEFAULT_INSTANCE;
        public static final int HEIGHT_FIELD_NUMBER = 3;
        private static volatile Parser<Rect> PARSER = null;
        public static final int RECT_ID_FIELD_NUMBER = 6;
        public static final int ROTATION_FIELD_NUMBER = 5;
        public static final int WIDTH_FIELD_NUMBER = 4;
        public static final int X_CENTER_FIELD_NUMBER = 1;
        public static final int Y_CENTER_FIELD_NUMBER = 2;
        private int bitField0_;
        private int height_;
        private byte memoizedIsInitialized = 2;
        private long rectId_;
        private float rotation_;
        private int width_;
        private int xCenter_;
        private int yCenter_;

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

        private Rect() {
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public boolean hasXCenter() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public int getXCenter() {
            return this.xCenter_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setXCenter(int i) {
            this.bitField0_ |= 1;
            this.xCenter_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearXCenter() {
            this.bitField0_ &= -2;
            this.xCenter_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public boolean hasYCenter() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public int getYCenter() {
            return this.yCenter_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setYCenter(int i) {
            this.bitField0_ |= 2;
            this.yCenter_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearYCenter() {
            this.bitField0_ &= -3;
            this.yCenter_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public boolean hasHeight() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public int getHeight() {
            return this.height_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeight(int i) {
            this.bitField0_ |= 4;
            this.height_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHeight() {
            this.bitField0_ &= -5;
            this.height_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public boolean hasWidth() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public int getWidth() {
            return this.width_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setWidth(int i) {
            this.bitField0_ |= 8;
            this.width_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearWidth() {
            this.bitField0_ &= -9;
            this.width_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public boolean hasRotation() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public float getRotation() {
            return this.rotation_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRotation(float f) {
            this.bitField0_ |= 16;
            this.rotation_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRotation() {
            this.bitField0_ &= -17;
            this.rotation_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public boolean hasRectId() {
            return (this.bitField0_ & 32) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
        public long getRectId() {
            return this.rectId_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRectId(long j) {
            this.bitField0_ |= 32;
            this.rectId_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRectId() {
            this.bitField0_ &= -33;
            this.rectId_ = 0L;
        }

        public static Rect parseFrom(ByteBuffer byteBuffer) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Rect parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Rect parseFrom(ByteString byteString) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Rect parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Rect parseFrom(byte[] bArr) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Rect parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Rect parseFrom(InputStream inputStream) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Rect parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Rect parseDelimitedFrom(InputStream inputStream) {
            return (Rect) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Rect parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Rect) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Rect parseFrom(CodedInputStream codedInputStream) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Rect parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Rect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Rect rect) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(rect);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Rect, Builder> implements RectOrBuilder {
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
                super(Rect.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public boolean hasXCenter() {
                return ((Rect) this.instance).hasXCenter();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public int getXCenter() {
                return ((Rect) this.instance).getXCenter();
            }

            public Builder setXCenter(int i) {
                copyOnWrite();
                ((Rect) this.instance).setXCenter(i);
                return this;
            }

            public Builder clearXCenter() {
                copyOnWrite();
                ((Rect) this.instance).clearXCenter();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public boolean hasYCenter() {
                return ((Rect) this.instance).hasYCenter();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public int getYCenter() {
                return ((Rect) this.instance).getYCenter();
            }

            public Builder setYCenter(int i) {
                copyOnWrite();
                ((Rect) this.instance).setYCenter(i);
                return this;
            }

            public Builder clearYCenter() {
                copyOnWrite();
                ((Rect) this.instance).clearYCenter();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public boolean hasHeight() {
                return ((Rect) this.instance).hasHeight();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public int getHeight() {
                return ((Rect) this.instance).getHeight();
            }

            public Builder setHeight(int i) {
                copyOnWrite();
                ((Rect) this.instance).setHeight(i);
                return this;
            }

            public Builder clearHeight() {
                copyOnWrite();
                ((Rect) this.instance).clearHeight();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public boolean hasWidth() {
                return ((Rect) this.instance).hasWidth();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public int getWidth() {
                return ((Rect) this.instance).getWidth();
            }

            public Builder setWidth(int i) {
                copyOnWrite();
                ((Rect) this.instance).setWidth(i);
                return this;
            }

            public Builder clearWidth() {
                copyOnWrite();
                ((Rect) this.instance).clearWidth();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public boolean hasRotation() {
                return ((Rect) this.instance).hasRotation();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public float getRotation() {
                return ((Rect) this.instance).getRotation();
            }

            public Builder setRotation(float f) {
                copyOnWrite();
                ((Rect) this.instance).setRotation(f);
                return this;
            }

            public Builder clearRotation() {
                copyOnWrite();
                ((Rect) this.instance).clearRotation();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public boolean hasRectId() {
                return ((Rect) this.instance).hasRectId();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.RectOrBuilder
            public long getRectId() {
                return ((Rect) this.instance).getRectId();
            }

            public Builder setRectId(long j) {
                copyOnWrite();
                ((Rect) this.instance).setRectId(j);
                return this;
            }

            public Builder clearRectId() {
                copyOnWrite();
                ((Rect) this.instance).clearRectId();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Rect();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0006\u0000\u0001\u0001\u0006\u0006\u0000\u0000\u0004\u0001ᔄ\u0000\u0002ᔄ\u0001\u0003ᔄ\u0002\u0004ᔄ\u0003\u0005ခ\u0004\u0006ဂ\u0005", new Object[]{"bitField0_", "xCenter_", "yCenter_", "height_", "width_", "rotation_", "rectId_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Rect> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Rect.class) {
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
                    return Byte.valueOf(this.memoizedIsInitialized);
                case 7:
                    this.memoizedIsInitialized = (byte) (obj == null ? 0 : 1);
                    return null;
                default:
                    throw new UnsupportedOperationException();
            }
        }

        static {
            Rect rect = new Rect();
            DEFAULT_INSTANCE = rect;
            GeneratedMessageLite.registerDefaultInstance(Rect.class, rect);
        }

        public static Rect getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Rect> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.formats.proto.RectProto$1, reason: invalid class name */
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

    public static final class NormalizedRect extends GeneratedMessageLite<NormalizedRect, Builder> implements NormalizedRectOrBuilder {
        private static final NormalizedRect DEFAULT_INSTANCE;
        public static final int HEIGHT_FIELD_NUMBER = 3;
        private static volatile Parser<NormalizedRect> PARSER = null;
        public static final int RECT_ID_FIELD_NUMBER = 6;
        public static final int ROTATION_FIELD_NUMBER = 5;
        public static final int WIDTH_FIELD_NUMBER = 4;
        public static final int X_CENTER_FIELD_NUMBER = 1;
        public static final int Y_CENTER_FIELD_NUMBER = 2;
        private int bitField0_;
        private float height_;
        private byte memoizedIsInitialized = 2;
        private long rectId_;
        private float rotation_;
        private float width_;
        private float xCenter_;
        private float yCenter_;

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

        private NormalizedRect() {
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public boolean hasXCenter() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public float getXCenter() {
            return this.xCenter_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setXCenter(float f) {
            this.bitField0_ |= 1;
            this.xCenter_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearXCenter() {
            this.bitField0_ &= -2;
            this.xCenter_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public boolean hasYCenter() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public float getYCenter() {
            return this.yCenter_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setYCenter(float f) {
            this.bitField0_ |= 2;
            this.yCenter_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearYCenter() {
            this.bitField0_ &= -3;
            this.yCenter_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public boolean hasHeight() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public float getHeight() {
            return this.height_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeight(float f) {
            this.bitField0_ |= 4;
            this.height_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHeight() {
            this.bitField0_ &= -5;
            this.height_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public boolean hasWidth() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public float getWidth() {
            return this.width_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setWidth(float f) {
            this.bitField0_ |= 8;
            this.width_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearWidth() {
            this.bitField0_ &= -9;
            this.width_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public boolean hasRotation() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public float getRotation() {
            return this.rotation_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRotation(float f) {
            this.bitField0_ |= 16;
            this.rotation_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRotation() {
            this.bitField0_ &= -17;
            this.rotation_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public boolean hasRectId() {
            return (this.bitField0_ & 32) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
        public long getRectId() {
            return this.rectId_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRectId(long j) {
            this.bitField0_ |= 32;
            this.rectId_ = j;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRectId() {
            this.bitField0_ &= -33;
            this.rectId_ = 0L;
        }

        public static NormalizedRect parseFrom(ByteBuffer byteBuffer) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static NormalizedRect parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static NormalizedRect parseFrom(ByteString byteString) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static NormalizedRect parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static NormalizedRect parseFrom(byte[] bArr) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static NormalizedRect parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static NormalizedRect parseFrom(InputStream inputStream) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedRect parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedRect parseDelimitedFrom(InputStream inputStream) {
            return (NormalizedRect) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedRect parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedRect) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedRect parseFrom(CodedInputStream codedInputStream) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static NormalizedRect parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedRect) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(NormalizedRect normalizedRect) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(normalizedRect);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<NormalizedRect, Builder> implements NormalizedRectOrBuilder {
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
                super(NormalizedRect.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public boolean hasXCenter() {
                return ((NormalizedRect) this.instance).hasXCenter();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public float getXCenter() {
                return ((NormalizedRect) this.instance).getXCenter();
            }

            public Builder setXCenter(float f) {
                copyOnWrite();
                ((NormalizedRect) this.instance).setXCenter(f);
                return this;
            }

            public Builder clearXCenter() {
                copyOnWrite();
                ((NormalizedRect) this.instance).clearXCenter();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public boolean hasYCenter() {
                return ((NormalizedRect) this.instance).hasYCenter();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public float getYCenter() {
                return ((NormalizedRect) this.instance).getYCenter();
            }

            public Builder setYCenter(float f) {
                copyOnWrite();
                ((NormalizedRect) this.instance).setYCenter(f);
                return this;
            }

            public Builder clearYCenter() {
                copyOnWrite();
                ((NormalizedRect) this.instance).clearYCenter();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public boolean hasHeight() {
                return ((NormalizedRect) this.instance).hasHeight();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public float getHeight() {
                return ((NormalizedRect) this.instance).getHeight();
            }

            public Builder setHeight(float f) {
                copyOnWrite();
                ((NormalizedRect) this.instance).setHeight(f);
                return this;
            }

            public Builder clearHeight() {
                copyOnWrite();
                ((NormalizedRect) this.instance).clearHeight();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public boolean hasWidth() {
                return ((NormalizedRect) this.instance).hasWidth();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public float getWidth() {
                return ((NormalizedRect) this.instance).getWidth();
            }

            public Builder setWidth(float f) {
                copyOnWrite();
                ((NormalizedRect) this.instance).setWidth(f);
                return this;
            }

            public Builder clearWidth() {
                copyOnWrite();
                ((NormalizedRect) this.instance).clearWidth();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public boolean hasRotation() {
                return ((NormalizedRect) this.instance).hasRotation();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public float getRotation() {
                return ((NormalizedRect) this.instance).getRotation();
            }

            public Builder setRotation(float f) {
                copyOnWrite();
                ((NormalizedRect) this.instance).setRotation(f);
                return this;
            }

            public Builder clearRotation() {
                copyOnWrite();
                ((NormalizedRect) this.instance).clearRotation();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public boolean hasRectId() {
                return ((NormalizedRect) this.instance).hasRectId();
            }

            @Override // com.google.mediapipe.formats.proto.RectProto.NormalizedRectOrBuilder
            public long getRectId() {
                return ((NormalizedRect) this.instance).getRectId();
            }

            public Builder setRectId(long j) {
                copyOnWrite();
                ((NormalizedRect) this.instance).setRectId(j);
                return this;
            }

            public Builder clearRectId() {
                copyOnWrite();
                ((NormalizedRect) this.instance).clearRectId();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new NormalizedRect();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0006\u0000\u0001\u0001\u0006\u0006\u0000\u0000\u0004\u0001ᔁ\u0000\u0002ᔁ\u0001\u0003ᔁ\u0002\u0004ᔁ\u0003\u0005ခ\u0004\u0006ဂ\u0005", new Object[]{"bitField0_", "xCenter_", "yCenter_", "height_", "width_", "rotation_", "rectId_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<NormalizedRect> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (NormalizedRect.class) {
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
                    return Byte.valueOf(this.memoizedIsInitialized);
                case 7:
                    this.memoizedIsInitialized = (byte) (obj == null ? 0 : 1);
                    return null;
                default:
                    throw new UnsupportedOperationException();
            }
        }

        static {
            NormalizedRect normalizedRect = new NormalizedRect();
            DEFAULT_INSTANCE = normalizedRect;
            GeneratedMessageLite.registerDefaultInstance(NormalizedRect.class, normalizedRect);
        }

        public static NormalizedRect getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<NormalizedRect> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
