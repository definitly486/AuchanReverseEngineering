package com.google.mediapipe.formats.proto;

import com.google.mediapipe.formats.annotation.proto.RasterizationProto;
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
public final class LocationDataProto {

    public interface LocationDataOrBuilder extends MessageLiteOrBuilder {
        LocationData.BoundingBox getBoundingBox();

        LocationData.Format getFormat();

        LocationData.BinaryMask getMask();

        LocationData.RelativeBoundingBox getRelativeBoundingBox();

        LocationData.RelativeKeypoint getRelativeKeypoints(int i);

        int getRelativeKeypointsCount();

        List<LocationData.RelativeKeypoint> getRelativeKeypointsList();

        boolean hasBoundingBox();

        boolean hasFormat();

        boolean hasMask();

        boolean hasRelativeBoundingBox();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private LocationDataProto() {
    }

    public static final class LocationData extends GeneratedMessageLite<LocationData, Builder> implements LocationDataOrBuilder {
        public static final int BOUNDING_BOX_FIELD_NUMBER = 2;
        private static final LocationData DEFAULT_INSTANCE;
        public static final int FORMAT_FIELD_NUMBER = 1;
        public static final int MASK_FIELD_NUMBER = 4;
        private static volatile Parser<LocationData> PARSER = null;
        public static final int RELATIVE_BOUNDING_BOX_FIELD_NUMBER = 3;
        public static final int RELATIVE_KEYPOINTS_FIELD_NUMBER = 5;
        private int bitField0_;
        private BoundingBox boundingBox_;
        private int format_;
        private BinaryMask mask_;
        private RelativeBoundingBox relativeBoundingBox_;
        private byte memoizedIsInitialized = 2;
        private Internal.ProtobufList<RelativeKeypoint> relativeKeypoints_ = GeneratedMessageLite.emptyProtobufList();

        public interface BinaryMaskOrBuilder extends MessageLiteOrBuilder {
            int getHeight();

            RasterizationProto.Rasterization getRasterization();

            int getWidth();

            boolean hasHeight();

            boolean hasRasterization();

            boolean hasWidth();
        }

        public interface BoundingBoxOrBuilder extends MessageLiteOrBuilder {
            int getHeight();

            int getWidth();

            int getXmin();

            int getYmin();

            boolean hasHeight();

            boolean hasWidth();

            boolean hasXmin();

            boolean hasYmin();
        }

        public interface RelativeBoundingBoxOrBuilder extends MessageLiteOrBuilder {
            float getHeight();

            float getWidth();

            float getXmin();

            float getYmin();

            boolean hasHeight();

            boolean hasWidth();

            boolean hasXmin();

            boolean hasYmin();
        }

        public interface RelativeKeypointOrBuilder extends MessageLiteOrBuilder {
            String getKeypointLabel();

            ByteString getKeypointLabelBytes();

            float getScore();

            float getX();

            float getY();

            boolean hasKeypointLabel();

            boolean hasScore();

            boolean hasX();

            boolean hasY();
        }

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

        private LocationData() {
        }

        public enum Format implements Internal.EnumLite {
            GLOBAL(0),
            BOUNDING_BOX(1),
            RELATIVE_BOUNDING_BOX(2),
            MASK(3);

            public static final int BOUNDING_BOX_VALUE = 1;
            public static final int GLOBAL_VALUE = 0;
            public static final int MASK_VALUE = 3;
            public static final int RELATIVE_BOUNDING_BOX_VALUE = 2;
            private static final Internal.EnumLiteMap<Format> internalValueMap = new Internal.EnumLiteMap<Format>() { // from class: com.google.mediapipe.formats.proto.LocationDataProto.LocationData.Format.1
                @Override // com.google.protobuf.Internal.EnumLiteMap
                public Format findValueByNumber(int i) {
                    return Format.forNumber(i);
                }
            };
            private final int value;

            @Override // com.google.protobuf.Internal.EnumLite
            public final int getNumber() {
                return this.value;
            }

            @Deprecated
            public static Format valueOf(int i) {
                return forNumber(i);
            }

            public static Format forNumber(int i) {
                if (i == 0) {
                    return GLOBAL;
                }
                if (i == 1) {
                    return BOUNDING_BOX;
                }
                if (i == 2) {
                    return RELATIVE_BOUNDING_BOX;
                }
                if (i != 3) {
                    return null;
                }
                return MASK;
            }

            public static Internal.EnumLiteMap<Format> internalGetValueMap() {
                return internalValueMap;
            }

            public static Internal.EnumVerifier internalGetVerifier() {
                return FormatVerifier.INSTANCE;
            }

            private static final class FormatVerifier implements Internal.EnumVerifier {
                static final Internal.EnumVerifier INSTANCE = new FormatVerifier();

                private FormatVerifier() {
                }

                @Override // com.google.protobuf.Internal.EnumVerifier
                public boolean isInRange(int i) {
                    return Format.forNumber(i) != null;
                }
            }

            Format(int i) {
                this.value = i;
            }
        }

        public static final class BoundingBox extends GeneratedMessageLite<BoundingBox, Builder> implements BoundingBoxOrBuilder {
            private static final BoundingBox DEFAULT_INSTANCE;
            public static final int HEIGHT_FIELD_NUMBER = 4;
            private static volatile Parser<BoundingBox> PARSER = null;
            public static final int WIDTH_FIELD_NUMBER = 3;
            public static final int XMIN_FIELD_NUMBER = 1;
            public static final int YMIN_FIELD_NUMBER = 2;
            private int bitField0_;
            private int height_;
            private int width_;
            private int xmin_;
            private int ymin_;

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

            private BoundingBox() {
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public boolean hasXmin() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public int getXmin() {
                return this.xmin_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXmin(int i) {
                this.bitField0_ |= 1;
                this.xmin_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXmin() {
                this.bitField0_ &= -2;
                this.xmin_ = 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public boolean hasYmin() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public int getYmin() {
                return this.ymin_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYmin(int i) {
                this.bitField0_ |= 2;
                this.ymin_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYmin() {
                this.bitField0_ &= -3;
                this.ymin_ = 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public boolean hasWidth() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public int getWidth() {
                return this.width_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setWidth(int i) {
                this.bitField0_ |= 4;
                this.width_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearWidth() {
                this.bitField0_ &= -5;
                this.width_ = 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public boolean hasHeight() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
            public int getHeight() {
                return this.height_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setHeight(int i) {
                this.bitField0_ |= 8;
                this.height_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearHeight() {
                this.bitField0_ &= -9;
                this.height_ = 0;
            }

            public static BoundingBox parseFrom(ByteBuffer byteBuffer) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static BoundingBox parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static BoundingBox parseFrom(ByteString byteString) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static BoundingBox parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static BoundingBox parseFrom(byte[] bArr) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static BoundingBox parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static BoundingBox parseFrom(InputStream inputStream) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static BoundingBox parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static BoundingBox parseDelimitedFrom(InputStream inputStream) {
                return (BoundingBox) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static BoundingBox parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (BoundingBox) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static BoundingBox parseFrom(CodedInputStream codedInputStream) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static BoundingBox parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (BoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(BoundingBox boundingBox) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(boundingBox);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<BoundingBox, Builder> implements BoundingBoxOrBuilder {
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
                    super(BoundingBox.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public boolean hasXmin() {
                    return ((BoundingBox) this.instance).hasXmin();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public int getXmin() {
                    return ((BoundingBox) this.instance).getXmin();
                }

                public Builder setXmin(int i) {
                    copyOnWrite();
                    ((BoundingBox) this.instance).setXmin(i);
                    return this;
                }

                public Builder clearXmin() {
                    copyOnWrite();
                    ((BoundingBox) this.instance).clearXmin();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public boolean hasYmin() {
                    return ((BoundingBox) this.instance).hasYmin();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public int getYmin() {
                    return ((BoundingBox) this.instance).getYmin();
                }

                public Builder setYmin(int i) {
                    copyOnWrite();
                    ((BoundingBox) this.instance).setYmin(i);
                    return this;
                }

                public Builder clearYmin() {
                    copyOnWrite();
                    ((BoundingBox) this.instance).clearYmin();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public boolean hasWidth() {
                    return ((BoundingBox) this.instance).hasWidth();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public int getWidth() {
                    return ((BoundingBox) this.instance).getWidth();
                }

                public Builder setWidth(int i) {
                    copyOnWrite();
                    ((BoundingBox) this.instance).setWidth(i);
                    return this;
                }

                public Builder clearWidth() {
                    copyOnWrite();
                    ((BoundingBox) this.instance).clearWidth();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public boolean hasHeight() {
                    return ((BoundingBox) this.instance).hasHeight();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BoundingBoxOrBuilder
                public int getHeight() {
                    return ((BoundingBox) this.instance).getHeight();
                }

                public Builder setHeight(int i) {
                    copyOnWrite();
                    ((BoundingBox) this.instance).setHeight(i);
                    return this;
                }

                public Builder clearHeight() {
                    copyOnWrite();
                    ((BoundingBox) this.instance).clearHeight();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new BoundingBox();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001င\u0000\u0002င\u0001\u0003င\u0002\u0004င\u0003", new Object[]{"bitField0_", "xmin_", "ymin_", "width_", "height_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<BoundingBox> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (BoundingBox.class) {
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
                BoundingBox boundingBox = new BoundingBox();
                DEFAULT_INSTANCE = boundingBox;
                GeneratedMessageLite.registerDefaultInstance(BoundingBox.class, boundingBox);
            }

            public static BoundingBox getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<BoundingBox> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class RelativeBoundingBox extends GeneratedMessageLite<RelativeBoundingBox, Builder> implements RelativeBoundingBoxOrBuilder {
            private static final RelativeBoundingBox DEFAULT_INSTANCE;
            public static final int HEIGHT_FIELD_NUMBER = 4;
            private static volatile Parser<RelativeBoundingBox> PARSER = null;
            public static final int WIDTH_FIELD_NUMBER = 3;
            public static final int XMIN_FIELD_NUMBER = 1;
            public static final int YMIN_FIELD_NUMBER = 2;
            private int bitField0_;
            private float height_;
            private float width_;
            private float xmin_;
            private float ymin_;

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

            private RelativeBoundingBox() {
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public boolean hasXmin() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public float getXmin() {
                return this.xmin_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXmin(float f) {
                this.bitField0_ |= 1;
                this.xmin_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXmin() {
                this.bitField0_ &= -2;
                this.xmin_ = 0.0f;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public boolean hasYmin() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public float getYmin() {
                return this.ymin_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYmin(float f) {
                this.bitField0_ |= 2;
                this.ymin_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYmin() {
                this.bitField0_ &= -3;
                this.ymin_ = 0.0f;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public boolean hasWidth() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public float getWidth() {
                return this.width_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setWidth(float f) {
                this.bitField0_ |= 4;
                this.width_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearWidth() {
                this.bitField0_ &= -5;
                this.width_ = 0.0f;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public boolean hasHeight() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
            public float getHeight() {
                return this.height_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setHeight(float f) {
                this.bitField0_ |= 8;
                this.height_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearHeight() {
                this.bitField0_ &= -9;
                this.height_ = 0.0f;
            }

            public static RelativeBoundingBox parseFrom(ByteBuffer byteBuffer) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static RelativeBoundingBox parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static RelativeBoundingBox parseFrom(ByteString byteString) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static RelativeBoundingBox parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static RelativeBoundingBox parseFrom(byte[] bArr) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static RelativeBoundingBox parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static RelativeBoundingBox parseFrom(InputStream inputStream) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static RelativeBoundingBox parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static RelativeBoundingBox parseDelimitedFrom(InputStream inputStream) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static RelativeBoundingBox parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static RelativeBoundingBox parseFrom(CodedInputStream codedInputStream) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static RelativeBoundingBox parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeBoundingBox) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(RelativeBoundingBox relativeBoundingBox) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(relativeBoundingBox);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<RelativeBoundingBox, Builder> implements RelativeBoundingBoxOrBuilder {
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
                    super(RelativeBoundingBox.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public boolean hasXmin() {
                    return ((RelativeBoundingBox) this.instance).hasXmin();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public float getXmin() {
                    return ((RelativeBoundingBox) this.instance).getXmin();
                }

                public Builder setXmin(float f) {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).setXmin(f);
                    return this;
                }

                public Builder clearXmin() {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).clearXmin();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public boolean hasYmin() {
                    return ((RelativeBoundingBox) this.instance).hasYmin();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public float getYmin() {
                    return ((RelativeBoundingBox) this.instance).getYmin();
                }

                public Builder setYmin(float f) {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).setYmin(f);
                    return this;
                }

                public Builder clearYmin() {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).clearYmin();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public boolean hasWidth() {
                    return ((RelativeBoundingBox) this.instance).hasWidth();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public float getWidth() {
                    return ((RelativeBoundingBox) this.instance).getWidth();
                }

                public Builder setWidth(float f) {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).setWidth(f);
                    return this;
                }

                public Builder clearWidth() {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).clearWidth();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public boolean hasHeight() {
                    return ((RelativeBoundingBox) this.instance).hasHeight();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeBoundingBoxOrBuilder
                public float getHeight() {
                    return ((RelativeBoundingBox) this.instance).getHeight();
                }

                public Builder setHeight(float f) {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).setHeight(f);
                    return this;
                }

                public Builder clearHeight() {
                    copyOnWrite();
                    ((RelativeBoundingBox) this.instance).clearHeight();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new RelativeBoundingBox();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001ခ\u0000\u0002ခ\u0001\u0003ခ\u0002\u0004ခ\u0003", new Object[]{"bitField0_", "xmin_", "ymin_", "width_", "height_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<RelativeBoundingBox> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (RelativeBoundingBox.class) {
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
                RelativeBoundingBox relativeBoundingBox = new RelativeBoundingBox();
                DEFAULT_INSTANCE = relativeBoundingBox;
                GeneratedMessageLite.registerDefaultInstance(RelativeBoundingBox.class, relativeBoundingBox);
            }

            public static RelativeBoundingBox getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<RelativeBoundingBox> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class BinaryMask extends GeneratedMessageLite<BinaryMask, Builder> implements BinaryMaskOrBuilder {
            private static final BinaryMask DEFAULT_INSTANCE;
            public static final int HEIGHT_FIELD_NUMBER = 2;
            private static volatile Parser<BinaryMask> PARSER = null;
            public static final int RASTERIZATION_FIELD_NUMBER = 3;
            public static final int WIDTH_FIELD_NUMBER = 1;
            private int bitField0_;
            private int height_;
            private byte memoizedIsInitialized = 2;
            private RasterizationProto.Rasterization rasterization_;
            private int width_;

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

            private BinaryMask() {
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
            public boolean hasWidth() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
            public int getWidth() {
                return this.width_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setWidth(int i) {
                this.bitField0_ |= 1;
                this.width_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearWidth() {
                this.bitField0_ &= -2;
                this.width_ = 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
            public boolean hasHeight() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
            public int getHeight() {
                return this.height_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setHeight(int i) {
                this.bitField0_ |= 2;
                this.height_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearHeight() {
                this.bitField0_ &= -3;
                this.height_ = 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
            public boolean hasRasterization() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
            public RasterizationProto.Rasterization getRasterization() {
                RasterizationProto.Rasterization rasterization = this.rasterization_;
                return rasterization == null ? RasterizationProto.Rasterization.getDefaultInstance() : rasterization;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRasterization(RasterizationProto.Rasterization rasterization) {
                rasterization.getClass();
                this.rasterization_ = rasterization;
                this.bitField0_ |= 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeRasterization(RasterizationProto.Rasterization rasterization) {
                rasterization.getClass();
                RasterizationProto.Rasterization rasterization2 = this.rasterization_;
                if (rasterization2 != null && rasterization2 != RasterizationProto.Rasterization.getDefaultInstance()) {
                    this.rasterization_ = RasterizationProto.Rasterization.newBuilder(this.rasterization_).mergeFrom(rasterization).buildPartial();
                } else {
                    this.rasterization_ = rasterization;
                }
                this.bitField0_ |= 4;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRasterization() {
                this.rasterization_ = null;
                this.bitField0_ &= -5;
            }

            public static BinaryMask parseFrom(ByteBuffer byteBuffer) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static BinaryMask parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static BinaryMask parseFrom(ByteString byteString) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static BinaryMask parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static BinaryMask parseFrom(byte[] bArr) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static BinaryMask parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static BinaryMask parseFrom(InputStream inputStream) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static BinaryMask parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static BinaryMask parseDelimitedFrom(InputStream inputStream) {
                return (BinaryMask) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static BinaryMask parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (BinaryMask) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static BinaryMask parseFrom(CodedInputStream codedInputStream) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static BinaryMask parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (BinaryMask) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(BinaryMask binaryMask) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(binaryMask);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<BinaryMask, Builder> implements BinaryMaskOrBuilder {
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
                    super(BinaryMask.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
                public boolean hasWidth() {
                    return ((BinaryMask) this.instance).hasWidth();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
                public int getWidth() {
                    return ((BinaryMask) this.instance).getWidth();
                }

                public Builder setWidth(int i) {
                    copyOnWrite();
                    ((BinaryMask) this.instance).setWidth(i);
                    return this;
                }

                public Builder clearWidth() {
                    copyOnWrite();
                    ((BinaryMask) this.instance).clearWidth();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
                public boolean hasHeight() {
                    return ((BinaryMask) this.instance).hasHeight();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
                public int getHeight() {
                    return ((BinaryMask) this.instance).getHeight();
                }

                public Builder setHeight(int i) {
                    copyOnWrite();
                    ((BinaryMask) this.instance).setHeight(i);
                    return this;
                }

                public Builder clearHeight() {
                    copyOnWrite();
                    ((BinaryMask) this.instance).clearHeight();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
                public boolean hasRasterization() {
                    return ((BinaryMask) this.instance).hasRasterization();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.BinaryMaskOrBuilder
                public RasterizationProto.Rasterization getRasterization() {
                    return ((BinaryMask) this.instance).getRasterization();
                }

                public Builder setRasterization(RasterizationProto.Rasterization rasterization) {
                    copyOnWrite();
                    ((BinaryMask) this.instance).setRasterization(rasterization);
                    return this;
                }

                public Builder setRasterization(RasterizationProto.Rasterization.Builder builder) {
                    copyOnWrite();
                    ((BinaryMask) this.instance).setRasterization(builder.build());
                    return this;
                }

                public Builder mergeRasterization(RasterizationProto.Rasterization rasterization) {
                    copyOnWrite();
                    ((BinaryMask) this.instance).mergeRasterization(rasterization);
                    return this;
                }

                public Builder clearRasterization() {
                    copyOnWrite();
                    ((BinaryMask) this.instance).clearRasterization();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new BinaryMask();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0001\u0001င\u0000\u0002င\u0001\u0003ᐉ\u0002", new Object[]{"bitField0_", "width_", "height_", "rasterization_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<BinaryMask> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (BinaryMask.class) {
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
                BinaryMask binaryMask = new BinaryMask();
                DEFAULT_INSTANCE = binaryMask;
                GeneratedMessageLite.registerDefaultInstance(BinaryMask.class, binaryMask);
            }

            public static BinaryMask getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<BinaryMask> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class RelativeKeypoint extends GeneratedMessageLite<RelativeKeypoint, Builder> implements RelativeKeypointOrBuilder {
            private static final RelativeKeypoint DEFAULT_INSTANCE;
            public static final int KEYPOINT_LABEL_FIELD_NUMBER = 3;
            private static volatile Parser<RelativeKeypoint> PARSER = null;
            public static final int SCORE_FIELD_NUMBER = 4;
            public static final int X_FIELD_NUMBER = 1;
            public static final int Y_FIELD_NUMBER = 2;
            private int bitField0_;
            private String keypointLabel_ = "";
            private float score_;
            private float x_;
            private float y_;

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

            private RelativeKeypoint() {
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public boolean hasX() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public float getX() {
                return this.x_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setX(float f) {
                this.bitField0_ |= 1;
                this.x_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearX() {
                this.bitField0_ &= -2;
                this.x_ = 0.0f;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public boolean hasY() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public float getY() {
                return this.y_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setY(float f) {
                this.bitField0_ |= 2;
                this.y_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearY() {
                this.bitField0_ &= -3;
                this.y_ = 0.0f;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public boolean hasKeypointLabel() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public String getKeypointLabel() {
                return this.keypointLabel_;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public ByteString getKeypointLabelBytes() {
                return ByteString.copyFromUtf8(this.keypointLabel_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setKeypointLabel(String str) {
                str.getClass();
                this.bitField0_ |= 4;
                this.keypointLabel_ = str;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearKeypointLabel() {
                this.bitField0_ &= -5;
                this.keypointLabel_ = getDefaultInstance().getKeypointLabel();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setKeypointLabelBytes(ByteString byteString) {
                this.keypointLabel_ = byteString.toStringUtf8();
                this.bitField0_ |= 4;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public boolean hasScore() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
            public float getScore() {
                return this.score_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setScore(float f) {
                this.bitField0_ |= 8;
                this.score_ = f;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearScore() {
                this.bitField0_ &= -9;
                this.score_ = 0.0f;
            }

            public static RelativeKeypoint parseFrom(ByteBuffer byteBuffer) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static RelativeKeypoint parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static RelativeKeypoint parseFrom(ByteString byteString) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static RelativeKeypoint parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static RelativeKeypoint parseFrom(byte[] bArr) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static RelativeKeypoint parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static RelativeKeypoint parseFrom(InputStream inputStream) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static RelativeKeypoint parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static RelativeKeypoint parseDelimitedFrom(InputStream inputStream) {
                return (RelativeKeypoint) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static RelativeKeypoint parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeKeypoint) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static RelativeKeypoint parseFrom(CodedInputStream codedInputStream) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static RelativeKeypoint parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RelativeKeypoint) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(RelativeKeypoint relativeKeypoint) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(relativeKeypoint);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<RelativeKeypoint, Builder> implements RelativeKeypointOrBuilder {
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
                    super(RelativeKeypoint.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public boolean hasX() {
                    return ((RelativeKeypoint) this.instance).hasX();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public float getX() {
                    return ((RelativeKeypoint) this.instance).getX();
                }

                public Builder setX(float f) {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).setX(f);
                    return this;
                }

                public Builder clearX() {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).clearX();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public boolean hasY() {
                    return ((RelativeKeypoint) this.instance).hasY();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public float getY() {
                    return ((RelativeKeypoint) this.instance).getY();
                }

                public Builder setY(float f) {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).setY(f);
                    return this;
                }

                public Builder clearY() {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).clearY();
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public boolean hasKeypointLabel() {
                    return ((RelativeKeypoint) this.instance).hasKeypointLabel();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public String getKeypointLabel() {
                    return ((RelativeKeypoint) this.instance).getKeypointLabel();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public ByteString getKeypointLabelBytes() {
                    return ((RelativeKeypoint) this.instance).getKeypointLabelBytes();
                }

                public Builder setKeypointLabel(String str) {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).setKeypointLabel(str);
                    return this;
                }

                public Builder clearKeypointLabel() {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).clearKeypointLabel();
                    return this;
                }

                public Builder setKeypointLabelBytes(ByteString byteString) {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).setKeypointLabelBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public boolean hasScore() {
                    return ((RelativeKeypoint) this.instance).hasScore();
                }

                @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationData.RelativeKeypointOrBuilder
                public float getScore() {
                    return ((RelativeKeypoint) this.instance).getScore();
                }

                public Builder setScore(float f) {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).setScore(f);
                    return this;
                }

                public Builder clearScore() {
                    copyOnWrite();
                    ((RelativeKeypoint) this.instance).clearScore();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new RelativeKeypoint();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001ခ\u0000\u0002ခ\u0001\u0003ဈ\u0002\u0004ခ\u0003", new Object[]{"bitField0_", "x_", "y_", "keypointLabel_", "score_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<RelativeKeypoint> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (RelativeKeypoint.class) {
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
                RelativeKeypoint relativeKeypoint = new RelativeKeypoint();
                DEFAULT_INSTANCE = relativeKeypoint;
                GeneratedMessageLite.registerDefaultInstance(RelativeKeypoint.class, relativeKeypoint);
            }

            public static RelativeKeypoint getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<RelativeKeypoint> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public boolean hasFormat() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public Format getFormat() {
            Format formatForNumber = Format.forNumber(this.format_);
            return formatForNumber == null ? Format.GLOBAL : formatForNumber;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFormat(Format format) {
            this.format_ = format.getNumber();
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFormat() {
            this.bitField0_ &= -2;
            this.format_ = 0;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public boolean hasBoundingBox() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public BoundingBox getBoundingBox() {
            BoundingBox boundingBox = this.boundingBox_;
            return boundingBox == null ? BoundingBox.getDefaultInstance() : boundingBox;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setBoundingBox(BoundingBox boundingBox) {
            boundingBox.getClass();
            this.boundingBox_ = boundingBox;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeBoundingBox(BoundingBox boundingBox) {
            boundingBox.getClass();
            BoundingBox boundingBox2 = this.boundingBox_;
            if (boundingBox2 != null && boundingBox2 != BoundingBox.getDefaultInstance()) {
                this.boundingBox_ = BoundingBox.newBuilder(this.boundingBox_).mergeFrom(boundingBox).buildPartial();
            } else {
                this.boundingBox_ = boundingBox;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearBoundingBox() {
            this.boundingBox_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public boolean hasRelativeBoundingBox() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public RelativeBoundingBox getRelativeBoundingBox() {
            RelativeBoundingBox relativeBoundingBox = this.relativeBoundingBox_;
            return relativeBoundingBox == null ? RelativeBoundingBox.getDefaultInstance() : relativeBoundingBox;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRelativeBoundingBox(RelativeBoundingBox relativeBoundingBox) {
            relativeBoundingBox.getClass();
            this.relativeBoundingBox_ = relativeBoundingBox;
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeRelativeBoundingBox(RelativeBoundingBox relativeBoundingBox) {
            relativeBoundingBox.getClass();
            RelativeBoundingBox relativeBoundingBox2 = this.relativeBoundingBox_;
            if (relativeBoundingBox2 != null && relativeBoundingBox2 != RelativeBoundingBox.getDefaultInstance()) {
                this.relativeBoundingBox_ = RelativeBoundingBox.newBuilder(this.relativeBoundingBox_).mergeFrom(relativeBoundingBox).buildPartial();
            } else {
                this.relativeBoundingBox_ = relativeBoundingBox;
            }
            this.bitField0_ |= 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRelativeBoundingBox() {
            this.relativeBoundingBox_ = null;
            this.bitField0_ &= -5;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public boolean hasMask() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public BinaryMask getMask() {
            BinaryMask binaryMask = this.mask_;
            return binaryMask == null ? BinaryMask.getDefaultInstance() : binaryMask;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setMask(BinaryMask binaryMask) {
            binaryMask.getClass();
            this.mask_ = binaryMask;
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeMask(BinaryMask binaryMask) {
            binaryMask.getClass();
            BinaryMask binaryMask2 = this.mask_;
            if (binaryMask2 != null && binaryMask2 != BinaryMask.getDefaultInstance()) {
                this.mask_ = BinaryMask.newBuilder(this.mask_).mergeFrom(binaryMask).buildPartial();
            } else {
                this.mask_ = binaryMask;
            }
            this.bitField0_ |= 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearMask() {
            this.mask_ = null;
            this.bitField0_ &= -9;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public List<RelativeKeypoint> getRelativeKeypointsList() {
            return this.relativeKeypoints_;
        }

        public List<? extends RelativeKeypointOrBuilder> getRelativeKeypointsOrBuilderList() {
            return this.relativeKeypoints_;
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public int getRelativeKeypointsCount() {
            return this.relativeKeypoints_.size();
        }

        @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
        public RelativeKeypoint getRelativeKeypoints(int i) {
            return this.relativeKeypoints_.get(i);
        }

        public RelativeKeypointOrBuilder getRelativeKeypointsOrBuilder(int i) {
            return this.relativeKeypoints_.get(i);
        }

        private void ensureRelativeKeypointsIsMutable() {
            Internal.ProtobufList<RelativeKeypoint> protobufList = this.relativeKeypoints_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.relativeKeypoints_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRelativeKeypoints(int i, RelativeKeypoint relativeKeypoint) {
            relativeKeypoint.getClass();
            ensureRelativeKeypointsIsMutable();
            this.relativeKeypoints_.set(i, relativeKeypoint);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addRelativeKeypoints(RelativeKeypoint relativeKeypoint) {
            relativeKeypoint.getClass();
            ensureRelativeKeypointsIsMutable();
            this.relativeKeypoints_.add(relativeKeypoint);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addRelativeKeypoints(int i, RelativeKeypoint relativeKeypoint) {
            relativeKeypoint.getClass();
            ensureRelativeKeypointsIsMutable();
            this.relativeKeypoints_.add(i, relativeKeypoint);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllRelativeKeypoints(Iterable<? extends RelativeKeypoint> iterable) {
            ensureRelativeKeypointsIsMutable();
            AbstractMessageLite.addAll(iterable, this.relativeKeypoints_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRelativeKeypoints() {
            this.relativeKeypoints_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeRelativeKeypoints(int i) {
            ensureRelativeKeypointsIsMutable();
            this.relativeKeypoints_.remove(i);
        }

        public static LocationData parseFrom(ByteBuffer byteBuffer) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static LocationData parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static LocationData parseFrom(ByteString byteString) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static LocationData parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static LocationData parseFrom(byte[] bArr) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static LocationData parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static LocationData parseFrom(InputStream inputStream) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LocationData parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LocationData parseDelimitedFrom(InputStream inputStream) {
            return (LocationData) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LocationData parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LocationData) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LocationData parseFrom(CodedInputStream codedInputStream) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static LocationData parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LocationData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(LocationData locationData) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(locationData);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<LocationData, Builder> implements LocationDataOrBuilder {
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
                super(LocationData.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public boolean hasFormat() {
                return ((LocationData) this.instance).hasFormat();
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public Format getFormat() {
                return ((LocationData) this.instance).getFormat();
            }

            public Builder setFormat(Format format) {
                copyOnWrite();
                ((LocationData) this.instance).setFormat(format);
                return this;
            }

            public Builder clearFormat() {
                copyOnWrite();
                ((LocationData) this.instance).clearFormat();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public boolean hasBoundingBox() {
                return ((LocationData) this.instance).hasBoundingBox();
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public BoundingBox getBoundingBox() {
                return ((LocationData) this.instance).getBoundingBox();
            }

            public Builder setBoundingBox(BoundingBox boundingBox) {
                copyOnWrite();
                ((LocationData) this.instance).setBoundingBox(boundingBox);
                return this;
            }

            public Builder setBoundingBox(BoundingBox.Builder builder) {
                copyOnWrite();
                ((LocationData) this.instance).setBoundingBox(builder.build());
                return this;
            }

            public Builder mergeBoundingBox(BoundingBox boundingBox) {
                copyOnWrite();
                ((LocationData) this.instance).mergeBoundingBox(boundingBox);
                return this;
            }

            public Builder clearBoundingBox() {
                copyOnWrite();
                ((LocationData) this.instance).clearBoundingBox();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public boolean hasRelativeBoundingBox() {
                return ((LocationData) this.instance).hasRelativeBoundingBox();
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public RelativeBoundingBox getRelativeBoundingBox() {
                return ((LocationData) this.instance).getRelativeBoundingBox();
            }

            public Builder setRelativeBoundingBox(RelativeBoundingBox relativeBoundingBox) {
                copyOnWrite();
                ((LocationData) this.instance).setRelativeBoundingBox(relativeBoundingBox);
                return this;
            }

            public Builder setRelativeBoundingBox(RelativeBoundingBox.Builder builder) {
                copyOnWrite();
                ((LocationData) this.instance).setRelativeBoundingBox(builder.build());
                return this;
            }

            public Builder mergeRelativeBoundingBox(RelativeBoundingBox relativeBoundingBox) {
                copyOnWrite();
                ((LocationData) this.instance).mergeRelativeBoundingBox(relativeBoundingBox);
                return this;
            }

            public Builder clearRelativeBoundingBox() {
                copyOnWrite();
                ((LocationData) this.instance).clearRelativeBoundingBox();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public boolean hasMask() {
                return ((LocationData) this.instance).hasMask();
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public BinaryMask getMask() {
                return ((LocationData) this.instance).getMask();
            }

            public Builder setMask(BinaryMask binaryMask) {
                copyOnWrite();
                ((LocationData) this.instance).setMask(binaryMask);
                return this;
            }

            public Builder setMask(BinaryMask.Builder builder) {
                copyOnWrite();
                ((LocationData) this.instance).setMask(builder.build());
                return this;
            }

            public Builder mergeMask(BinaryMask binaryMask) {
                copyOnWrite();
                ((LocationData) this.instance).mergeMask(binaryMask);
                return this;
            }

            public Builder clearMask() {
                copyOnWrite();
                ((LocationData) this.instance).clearMask();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public List<RelativeKeypoint> getRelativeKeypointsList() {
                return Collections.unmodifiableList(((LocationData) this.instance).getRelativeKeypointsList());
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public int getRelativeKeypointsCount() {
                return ((LocationData) this.instance).getRelativeKeypointsCount();
            }

            @Override // com.google.mediapipe.formats.proto.LocationDataProto.LocationDataOrBuilder
            public RelativeKeypoint getRelativeKeypoints(int i) {
                return ((LocationData) this.instance).getRelativeKeypoints(i);
            }

            public Builder setRelativeKeypoints(int i, RelativeKeypoint relativeKeypoint) {
                copyOnWrite();
                ((LocationData) this.instance).setRelativeKeypoints(i, relativeKeypoint);
                return this;
            }

            public Builder setRelativeKeypoints(int i, RelativeKeypoint.Builder builder) {
                copyOnWrite();
                ((LocationData) this.instance).setRelativeKeypoints(i, builder.build());
                return this;
            }

            public Builder addRelativeKeypoints(RelativeKeypoint relativeKeypoint) {
                copyOnWrite();
                ((LocationData) this.instance).addRelativeKeypoints(relativeKeypoint);
                return this;
            }

            public Builder addRelativeKeypoints(int i, RelativeKeypoint relativeKeypoint) {
                copyOnWrite();
                ((LocationData) this.instance).addRelativeKeypoints(i, relativeKeypoint);
                return this;
            }

            public Builder addRelativeKeypoints(RelativeKeypoint.Builder builder) {
                copyOnWrite();
                ((LocationData) this.instance).addRelativeKeypoints(builder.build());
                return this;
            }

            public Builder addRelativeKeypoints(int i, RelativeKeypoint.Builder builder) {
                copyOnWrite();
                ((LocationData) this.instance).addRelativeKeypoints(i, builder.build());
                return this;
            }

            public Builder addAllRelativeKeypoints(Iterable<? extends RelativeKeypoint> iterable) {
                copyOnWrite();
                ((LocationData) this.instance).addAllRelativeKeypoints(iterable);
                return this;
            }

            public Builder clearRelativeKeypoints() {
                copyOnWrite();
                ((LocationData) this.instance).clearRelativeKeypoints();
                return this;
            }

            public Builder removeRelativeKeypoints(int i) {
                copyOnWrite();
                ((LocationData) this.instance).removeRelativeKeypoints(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new LocationData();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0005\u0000\u0001\u0001\u0005\u0005\u0000\u0001\u0001\u0001᠌\u0000\u0002ဉ\u0001\u0003ဉ\u0002\u0004ᐉ\u0003\u0005\u001b", new Object[]{"bitField0_", "format_", Format.internalGetVerifier(), "boundingBox_", "relativeBoundingBox_", "mask_", "relativeKeypoints_", RelativeKeypoint.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<LocationData> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (LocationData.class) {
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
            LocationData locationData = new LocationData();
            DEFAULT_INSTANCE = locationData;
            GeneratedMessageLite.registerDefaultInstance(LocationData.class, locationData);
        }

        public static LocationData getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<LocationData> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.formats.proto.LocationDataProto$1, reason: invalid class name */
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
