package com.google.mediapipe.tasks.vision.interactivesegmenter.proto;

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
public final class RegionOfInterestProto {

    public interface PointOrBuilder extends MessageLiteOrBuilder {
        boolean getNormalized();

        float getX();

        float getY();
    }

    public interface RegionOfInterestOrBuilder extends MessageLiteOrBuilder {
        RegionOfInterest.FocusRegionCase getFocusRegionCase();

        Point getKeypoint();

        Scribble getScribble();

        boolean hasKeypoint();

        boolean hasScribble();
    }

    public interface ScribbleOrBuilder extends MessageLiteOrBuilder {
        Point getPoint(int i);

        int getPointCount();

        List<Point> getPointList();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private RegionOfInterestProto() {
    }

    public static final class Point extends GeneratedMessageLite<Point, Builder> implements PointOrBuilder {
        private static final Point DEFAULT_INSTANCE;
        public static final int NORMALIZED_FIELD_NUMBER = 3;
        private static volatile Parser<Point> PARSER = null;
        public static final int X_FIELD_NUMBER = 1;
        public static final int Y_FIELD_NUMBER = 2;
        private boolean normalized_;
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

        private Point() {
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.PointOrBuilder
        public float getX() {
            return this.x_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setX(float f) {
            this.x_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearX() {
            this.x_ = 0.0f;
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.PointOrBuilder
        public float getY() {
            return this.y_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setY(float f) {
            this.y_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearY() {
            this.y_ = 0.0f;
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.PointOrBuilder
        public boolean getNormalized() {
            return this.normalized_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setNormalized(boolean z) {
            this.normalized_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearNormalized() {
            this.normalized_ = false;
        }

        public static Point parseFrom(ByteBuffer byteBuffer) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Point parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Point parseFrom(ByteString byteString) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Point parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Point parseFrom(byte[] bArr) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Point parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Point parseFrom(InputStream inputStream) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Point parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Point parseDelimitedFrom(InputStream inputStream) {
            return (Point) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Point parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Point) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Point parseFrom(CodedInputStream codedInputStream) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Point parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Point) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Point point) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(point);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Point, Builder> implements PointOrBuilder {
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
                super(Point.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.PointOrBuilder
            public float getX() {
                return ((Point) this.instance).getX();
            }

            public Builder setX(float f) {
                copyOnWrite();
                ((Point) this.instance).setX(f);
                return this;
            }

            public Builder clearX() {
                copyOnWrite();
                ((Point) this.instance).clearX();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.PointOrBuilder
            public float getY() {
                return ((Point) this.instance).getY();
            }

            public Builder setY(float f) {
                copyOnWrite();
                ((Point) this.instance).setY(f);
                return this;
            }

            public Builder clearY() {
                copyOnWrite();
                ((Point) this.instance).clearY();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.PointOrBuilder
            public boolean getNormalized() {
                return ((Point) this.instance).getNormalized();
            }

            public Builder setNormalized(boolean z) {
                copyOnWrite();
                ((Point) this.instance).setNormalized(z);
                return this;
            }

            public Builder clearNormalized() {
                copyOnWrite();
                ((Point) this.instance).clearNormalized();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Point();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0003\u0000\u0000\u0001\u0003\u0003\u0000\u0000\u0000\u0001\u0001\u0002\u0001\u0003\u0007", new Object[]{"x_", "y_", "normalized_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Point> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Point.class) {
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
            Point point = new Point();
            DEFAULT_INSTANCE = point;
            GeneratedMessageLite.registerDefaultInstance(Point.class, point);
        }

        public static Point getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Point> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto$1, reason: invalid class name */
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

    public static final class Scribble extends GeneratedMessageLite<Scribble, Builder> implements ScribbleOrBuilder {
        private static final Scribble DEFAULT_INSTANCE;
        private static volatile Parser<Scribble> PARSER = null;
        public static final int POINT_FIELD_NUMBER = 1;
        private Internal.ProtobufList<Point> point_ = GeneratedMessageLite.emptyProtobufList();

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

        private Scribble() {
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.ScribbleOrBuilder
        public List<Point> getPointList() {
            return this.point_;
        }

        public List<? extends PointOrBuilder> getPointOrBuilderList() {
            return this.point_;
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.ScribbleOrBuilder
        public int getPointCount() {
            return this.point_.size();
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.ScribbleOrBuilder
        public Point getPoint(int i) {
            return this.point_.get(i);
        }

        public PointOrBuilder getPointOrBuilder(int i) {
            return this.point_.get(i);
        }

        private void ensurePointIsMutable() {
            Internal.ProtobufList<Point> protobufList = this.point_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.point_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPoint(int i, Point point) {
            point.getClass();
            ensurePointIsMutable();
            this.point_.set(i, point);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPoint(Point point) {
            point.getClass();
            ensurePointIsMutable();
            this.point_.add(point);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addPoint(int i, Point point) {
            point.getClass();
            ensurePointIsMutable();
            this.point_.add(i, point);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllPoint(Iterable<? extends Point> iterable) {
            ensurePointIsMutable();
            AbstractMessageLite.addAll(iterable, this.point_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPoint() {
            this.point_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removePoint(int i) {
            ensurePointIsMutable();
            this.point_.remove(i);
        }

        public static Scribble parseFrom(ByteBuffer byteBuffer) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Scribble parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Scribble parseFrom(ByteString byteString) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Scribble parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Scribble parseFrom(byte[] bArr) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Scribble parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Scribble parseFrom(InputStream inputStream) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Scribble parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Scribble parseDelimitedFrom(InputStream inputStream) {
            return (Scribble) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Scribble parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Scribble) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Scribble parseFrom(CodedInputStream codedInputStream) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Scribble parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Scribble) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Scribble scribble) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(scribble);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Scribble, Builder> implements ScribbleOrBuilder {
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
                super(Scribble.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.ScribbleOrBuilder
            public List<Point> getPointList() {
                return Collections.unmodifiableList(((Scribble) this.instance).getPointList());
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.ScribbleOrBuilder
            public int getPointCount() {
                return ((Scribble) this.instance).getPointCount();
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.ScribbleOrBuilder
            public Point getPoint(int i) {
                return ((Scribble) this.instance).getPoint(i);
            }

            public Builder setPoint(int i, Point point) {
                copyOnWrite();
                ((Scribble) this.instance).setPoint(i, point);
                return this;
            }

            public Builder setPoint(int i, Point.Builder builder) {
                copyOnWrite();
                ((Scribble) this.instance).setPoint(i, builder.build());
                return this;
            }

            public Builder addPoint(Point point) {
                copyOnWrite();
                ((Scribble) this.instance).addPoint(point);
                return this;
            }

            public Builder addPoint(int i, Point point) {
                copyOnWrite();
                ((Scribble) this.instance).addPoint(i, point);
                return this;
            }

            public Builder addPoint(Point.Builder builder) {
                copyOnWrite();
                ((Scribble) this.instance).addPoint(builder.build());
                return this;
            }

            public Builder addPoint(int i, Point.Builder builder) {
                copyOnWrite();
                ((Scribble) this.instance).addPoint(i, builder.build());
                return this;
            }

            public Builder addAllPoint(Iterable<? extends Point> iterable) {
                copyOnWrite();
                ((Scribble) this.instance).addAllPoint(iterable);
                return this;
            }

            public Builder clearPoint() {
                copyOnWrite();
                ((Scribble) this.instance).clearPoint();
                return this;
            }

            public Builder removePoint(int i) {
                copyOnWrite();
                ((Scribble) this.instance).removePoint(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Scribble();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"point_", Point.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Scribble> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Scribble.class) {
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
            Scribble scribble = new Scribble();
            DEFAULT_INSTANCE = scribble;
            GeneratedMessageLite.registerDefaultInstance(Scribble.class, scribble);
        }

        public static Scribble getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Scribble> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class RegionOfInterest extends GeneratedMessageLite<RegionOfInterest, Builder> implements RegionOfInterestOrBuilder {
        private static final RegionOfInterest DEFAULT_INSTANCE;
        public static final int KEYPOINT_FIELD_NUMBER = 1;
        private static volatile Parser<RegionOfInterest> PARSER = null;
        public static final int SCRIBBLE_FIELD_NUMBER = 2;
        private int focusRegionCase_ = 0;
        private Object focusRegion_;

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

        private RegionOfInterest() {
        }

        public enum FocusRegionCase {
            KEYPOINT(1),
            SCRIBBLE(2),
            FOCUSREGION_NOT_SET(0);

            private final int value;

            FocusRegionCase(int i) {
                this.value = i;
            }

            @Deprecated
            public static FocusRegionCase valueOf(int i) {
                return forNumber(i);
            }

            public static FocusRegionCase forNumber(int i) {
                if (i == 0) {
                    return FOCUSREGION_NOT_SET;
                }
                if (i == 1) {
                    return KEYPOINT;
                }
                if (i != 2) {
                    return null;
                }
                return SCRIBBLE;
            }

            public int getNumber() {
                return this.value;
            }
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
        public FocusRegionCase getFocusRegionCase() {
            return FocusRegionCase.forNumber(this.focusRegionCase_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFocusRegion() {
            this.focusRegionCase_ = 0;
            this.focusRegion_ = null;
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
        public boolean hasKeypoint() {
            return this.focusRegionCase_ == 1;
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
        public Point getKeypoint() {
            if (this.focusRegionCase_ == 1) {
                return (Point) this.focusRegion_;
            }
            return Point.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setKeypoint(Point point) {
            point.getClass();
            this.focusRegion_ = point;
            this.focusRegionCase_ = 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeKeypoint(Point point) {
            point.getClass();
            if (this.focusRegionCase_ == 1 && this.focusRegion_ != Point.getDefaultInstance()) {
                this.focusRegion_ = Point.newBuilder((Point) this.focusRegion_).mergeFrom(point).buildPartial();
            } else {
                this.focusRegion_ = point;
            }
            this.focusRegionCase_ = 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearKeypoint() {
            if (this.focusRegionCase_ == 1) {
                this.focusRegionCase_ = 0;
                this.focusRegion_ = null;
            }
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
        public boolean hasScribble() {
            return this.focusRegionCase_ == 2;
        }

        @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
        public Scribble getScribble() {
            if (this.focusRegionCase_ == 2) {
                return (Scribble) this.focusRegion_;
            }
            return Scribble.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setScribble(Scribble scribble) {
            scribble.getClass();
            this.focusRegion_ = scribble;
            this.focusRegionCase_ = 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeScribble(Scribble scribble) {
            scribble.getClass();
            if (this.focusRegionCase_ == 2 && this.focusRegion_ != Scribble.getDefaultInstance()) {
                this.focusRegion_ = Scribble.newBuilder((Scribble) this.focusRegion_).mergeFrom(scribble).buildPartial();
            } else {
                this.focusRegion_ = scribble;
            }
            this.focusRegionCase_ = 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearScribble() {
            if (this.focusRegionCase_ == 2) {
                this.focusRegionCase_ = 0;
                this.focusRegion_ = null;
            }
        }

        public static RegionOfInterest parseFrom(ByteBuffer byteBuffer) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static RegionOfInterest parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static RegionOfInterest parseFrom(ByteString byteString) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static RegionOfInterest parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static RegionOfInterest parseFrom(byte[] bArr) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static RegionOfInterest parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static RegionOfInterest parseFrom(InputStream inputStream) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RegionOfInterest parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RegionOfInterest parseDelimitedFrom(InputStream inputStream) {
            return (RegionOfInterest) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RegionOfInterest parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RegionOfInterest) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RegionOfInterest parseFrom(CodedInputStream codedInputStream) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static RegionOfInterest parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RegionOfInterest) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(RegionOfInterest regionOfInterest) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(regionOfInterest);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<RegionOfInterest, Builder> implements RegionOfInterestOrBuilder {
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
                super(RegionOfInterest.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
            public FocusRegionCase getFocusRegionCase() {
                return ((RegionOfInterest) this.instance).getFocusRegionCase();
            }

            public Builder clearFocusRegion() {
                copyOnWrite();
                ((RegionOfInterest) this.instance).clearFocusRegion();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
            public boolean hasKeypoint() {
                return ((RegionOfInterest) this.instance).hasKeypoint();
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
            public Point getKeypoint() {
                return ((RegionOfInterest) this.instance).getKeypoint();
            }

            public Builder setKeypoint(Point point) {
                copyOnWrite();
                ((RegionOfInterest) this.instance).setKeypoint(point);
                return this;
            }

            public Builder setKeypoint(Point.Builder builder) {
                copyOnWrite();
                ((RegionOfInterest) this.instance).setKeypoint(builder.build());
                return this;
            }

            public Builder mergeKeypoint(Point point) {
                copyOnWrite();
                ((RegionOfInterest) this.instance).mergeKeypoint(point);
                return this;
            }

            public Builder clearKeypoint() {
                copyOnWrite();
                ((RegionOfInterest) this.instance).clearKeypoint();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
            public boolean hasScribble() {
                return ((RegionOfInterest) this.instance).hasScribble();
            }

            @Override // com.google.mediapipe.tasks.vision.interactivesegmenter.proto.RegionOfInterestProto.RegionOfInterestOrBuilder
            public Scribble getScribble() {
                return ((RegionOfInterest) this.instance).getScribble();
            }

            public Builder setScribble(Scribble scribble) {
                copyOnWrite();
                ((RegionOfInterest) this.instance).setScribble(scribble);
                return this;
            }

            public Builder setScribble(Scribble.Builder builder) {
                copyOnWrite();
                ((RegionOfInterest) this.instance).setScribble(builder.build());
                return this;
            }

            public Builder mergeScribble(Scribble scribble) {
                copyOnWrite();
                ((RegionOfInterest) this.instance).mergeScribble(scribble);
                return this;
            }

            public Builder clearScribble() {
                copyOnWrite();
                ((RegionOfInterest) this.instance).clearScribble();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new RegionOfInterest();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0002\u0001\u0000\u0001\u0002\u0002\u0000\u0000\u0000\u0001<\u0000\u0002<\u0000", new Object[]{"focusRegion_", "focusRegionCase_", Point.class, Scribble.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<RegionOfInterest> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (RegionOfInterest.class) {
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
            RegionOfInterest regionOfInterest = new RegionOfInterest();
            DEFAULT_INSTANCE = regionOfInterest;
            GeneratedMessageLite.registerDefaultInstance(RegionOfInterest.class, regionOfInterest);
        }

        public static RegionOfInterest getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<RegionOfInterest> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
