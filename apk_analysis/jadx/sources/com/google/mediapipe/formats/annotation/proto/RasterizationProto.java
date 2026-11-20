package com.google.mediapipe.formats.annotation.proto;

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
public final class RasterizationProto {

    public interface RasterizationOrBuilder extends MessageLiteOrBuilder {
        Rasterization.Interval getInterval(int i);

        int getIntervalCount();

        List<Rasterization.Interval> getIntervalList();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private RasterizationProto() {
    }

    public static final class Rasterization extends GeneratedMessageLite<Rasterization, Builder> implements RasterizationOrBuilder {
        private static final Rasterization DEFAULT_INSTANCE;
        public static final int INTERVAL_FIELD_NUMBER = 1;
        private static volatile Parser<Rasterization> PARSER;
        private byte memoizedIsInitialized = 2;
        private Internal.ProtobufList<Interval> interval_ = GeneratedMessageLite.emptyProtobufList();

        public interface IntervalOrBuilder extends MessageLiteOrBuilder {
            int getLeftX();

            int getRightX();

            int getY();

            boolean hasLeftX();

            boolean hasRightX();

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

        private Rasterization() {
        }

        public static final class Interval extends GeneratedMessageLite<Interval, Builder> implements IntervalOrBuilder {
            private static final Interval DEFAULT_INSTANCE;
            public static final int LEFT_X_FIELD_NUMBER = 2;
            private static volatile Parser<Interval> PARSER = null;
            public static final int RIGHT_X_FIELD_NUMBER = 3;
            public static final int Y_FIELD_NUMBER = 1;
            private int bitField0_;
            private int leftX_;
            private byte memoizedIsInitialized = 2;
            private int rightX_;
            private int y_;

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

            private Interval() {
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
            public boolean hasY() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
            public int getY() {
                return this.y_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setY(int i) {
                this.bitField0_ |= 1;
                this.y_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearY() {
                this.bitField0_ &= -2;
                this.y_ = 0;
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
            public boolean hasLeftX() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
            public int getLeftX() {
                return this.leftX_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setLeftX(int i) {
                this.bitField0_ |= 2;
                this.leftX_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearLeftX() {
                this.bitField0_ &= -3;
                this.leftX_ = 0;
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
            public boolean hasRightX() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
            public int getRightX() {
                return this.rightX_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRightX(int i) {
                this.bitField0_ |= 4;
                this.rightX_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRightX() {
                this.bitField0_ &= -5;
                this.rightX_ = 0;
            }

            public static Interval parseFrom(ByteBuffer byteBuffer) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Interval parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Interval parseFrom(ByteString byteString) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Interval parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Interval parseFrom(byte[] bArr) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Interval parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Interval parseFrom(InputStream inputStream) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Interval parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Interval parseDelimitedFrom(InputStream inputStream) {
                return (Interval) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Interval parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Interval) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Interval parseFrom(CodedInputStream codedInputStream) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Interval parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Interval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Interval interval) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(interval);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Interval, Builder> implements IntervalOrBuilder {
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
                    super(Interval.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
                public boolean hasY() {
                    return ((Interval) this.instance).hasY();
                }

                @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
                public int getY() {
                    return ((Interval) this.instance).getY();
                }

                public Builder setY(int i) {
                    copyOnWrite();
                    ((Interval) this.instance).setY(i);
                    return this;
                }

                public Builder clearY() {
                    copyOnWrite();
                    ((Interval) this.instance).clearY();
                    return this;
                }

                @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
                public boolean hasLeftX() {
                    return ((Interval) this.instance).hasLeftX();
                }

                @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
                public int getLeftX() {
                    return ((Interval) this.instance).getLeftX();
                }

                public Builder setLeftX(int i) {
                    copyOnWrite();
                    ((Interval) this.instance).setLeftX(i);
                    return this;
                }

                public Builder clearLeftX() {
                    copyOnWrite();
                    ((Interval) this.instance).clearLeftX();
                    return this;
                }

                @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
                public boolean hasRightX() {
                    return ((Interval) this.instance).hasRightX();
                }

                @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.Rasterization.IntervalOrBuilder
                public int getRightX() {
                    return ((Interval) this.instance).getRightX();
                }

                public Builder setRightX(int i) {
                    copyOnWrite();
                    ((Interval) this.instance).setRightX(i);
                    return this;
                }

                public Builder clearRightX() {
                    copyOnWrite();
                    ((Interval) this.instance).clearRightX();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Interval();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0003\u0001ᔄ\u0000\u0002ᔄ\u0001\u0003ᔄ\u0002", new Object[]{"bitField0_", "y_", "leftX_", "rightX_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Interval> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Interval.class) {
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
                Interval interval = new Interval();
                DEFAULT_INSTANCE = interval;
                GeneratedMessageLite.registerDefaultInstance(Interval.class, interval);
            }

            public static Interval getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Interval> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.RasterizationOrBuilder
        public List<Interval> getIntervalList() {
            return this.interval_;
        }

        public List<? extends IntervalOrBuilder> getIntervalOrBuilderList() {
            return this.interval_;
        }

        @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.RasterizationOrBuilder
        public int getIntervalCount() {
            return this.interval_.size();
        }

        @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.RasterizationOrBuilder
        public Interval getInterval(int i) {
            return this.interval_.get(i);
        }

        public IntervalOrBuilder getIntervalOrBuilder(int i) {
            return this.interval_.get(i);
        }

        private void ensureIntervalIsMutable() {
            Internal.ProtobufList<Interval> protobufList = this.interval_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.interval_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setInterval(int i, Interval interval) {
            interval.getClass();
            ensureIntervalIsMutable();
            this.interval_.set(i, interval);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInterval(Interval interval) {
            interval.getClass();
            ensureIntervalIsMutable();
            this.interval_.add(interval);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addInterval(int i, Interval interval) {
            interval.getClass();
            ensureIntervalIsMutable();
            this.interval_.add(i, interval);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllInterval(Iterable<? extends Interval> iterable) {
            ensureIntervalIsMutable();
            AbstractMessageLite.addAll(iterable, this.interval_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearInterval() {
            this.interval_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeInterval(int i) {
            ensureIntervalIsMutable();
            this.interval_.remove(i);
        }

        public static Rasterization parseFrom(ByteBuffer byteBuffer) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Rasterization parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Rasterization parseFrom(ByteString byteString) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Rasterization parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Rasterization parseFrom(byte[] bArr) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Rasterization parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Rasterization parseFrom(InputStream inputStream) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Rasterization parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Rasterization parseDelimitedFrom(InputStream inputStream) {
            return (Rasterization) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Rasterization parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Rasterization) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Rasterization parseFrom(CodedInputStream codedInputStream) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Rasterization parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Rasterization) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Rasterization rasterization) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(rasterization);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Rasterization, Builder> implements RasterizationOrBuilder {
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
                super(Rasterization.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.RasterizationOrBuilder
            public List<Interval> getIntervalList() {
                return Collections.unmodifiableList(((Rasterization) this.instance).getIntervalList());
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.RasterizationOrBuilder
            public int getIntervalCount() {
                return ((Rasterization) this.instance).getIntervalCount();
            }

            @Override // com.google.mediapipe.formats.annotation.proto.RasterizationProto.RasterizationOrBuilder
            public Interval getInterval(int i) {
                return ((Rasterization) this.instance).getInterval(i);
            }

            public Builder setInterval(int i, Interval interval) {
                copyOnWrite();
                ((Rasterization) this.instance).setInterval(i, interval);
                return this;
            }

            public Builder setInterval(int i, Interval.Builder builder) {
                copyOnWrite();
                ((Rasterization) this.instance).setInterval(i, builder.build());
                return this;
            }

            public Builder addInterval(Interval interval) {
                copyOnWrite();
                ((Rasterization) this.instance).addInterval(interval);
                return this;
            }

            public Builder addInterval(int i, Interval interval) {
                copyOnWrite();
                ((Rasterization) this.instance).addInterval(i, interval);
                return this;
            }

            public Builder addInterval(Interval.Builder builder) {
                copyOnWrite();
                ((Rasterization) this.instance).addInterval(builder.build());
                return this;
            }

            public Builder addInterval(int i, Interval.Builder builder) {
                copyOnWrite();
                ((Rasterization) this.instance).addInterval(i, builder.build());
                return this;
            }

            public Builder addAllInterval(Iterable<? extends Interval> iterable) {
                copyOnWrite();
                ((Rasterization) this.instance).addAllInterval(iterable);
                return this;
            }

            public Builder clearInterval() {
                copyOnWrite();
                ((Rasterization) this.instance).clearInterval();
                return this;
            }

            public Builder removeInterval(int i) {
                copyOnWrite();
                ((Rasterization) this.instance).removeInterval(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Rasterization();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0001\u0001Л", new Object[]{"interval_", Interval.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Rasterization> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Rasterization.class) {
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
            Rasterization rasterization = new Rasterization();
            DEFAULT_INSTANCE = rasterization;
            GeneratedMessageLite.registerDefaultInstance(Rasterization.class, rasterization);
        }

        public static Rasterization getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Rasterization> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.formats.annotation.proto.RasterizationProto$1, reason: invalid class name */
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
