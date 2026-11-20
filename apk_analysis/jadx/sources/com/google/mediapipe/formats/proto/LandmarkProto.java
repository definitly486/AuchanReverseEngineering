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
public final class LandmarkProto {

    public interface LandmarkListCollectionOrBuilder extends MessageLiteOrBuilder {
        LandmarkList getLandmarkList(int i);

        int getLandmarkListCount();

        List<LandmarkList> getLandmarkListList();
    }

    public interface LandmarkListOrBuilder extends MessageLiteOrBuilder {
        Landmark getLandmark(int i);

        int getLandmarkCount();

        List<Landmark> getLandmarkList();
    }

    public interface LandmarkOrBuilder extends MessageLiteOrBuilder {
        float getPresence();

        float getVisibility();

        float getX();

        float getY();

        float getZ();

        boolean hasPresence();

        boolean hasVisibility();

        boolean hasX();

        boolean hasY();

        boolean hasZ();
    }

    public interface NormalizedLandmarkListCollectionOrBuilder extends MessageLiteOrBuilder {
        NormalizedLandmarkList getLandmarkList(int i);

        int getLandmarkListCount();

        List<NormalizedLandmarkList> getLandmarkListList();
    }

    public interface NormalizedLandmarkListOrBuilder extends MessageLiteOrBuilder {
        NormalizedLandmark getLandmark(int i);

        int getLandmarkCount();

        List<NormalizedLandmark> getLandmarkList();
    }

    public interface NormalizedLandmarkOrBuilder extends MessageLiteOrBuilder {
        float getPresence();

        float getVisibility();

        float getX();

        float getY();

        float getZ();

        boolean hasPresence();

        boolean hasVisibility();

        boolean hasX();

        boolean hasY();

        boolean hasZ();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private LandmarkProto() {
    }

    public static final class Landmark extends GeneratedMessageLite<Landmark, Builder> implements LandmarkOrBuilder {
        private static final Landmark DEFAULT_INSTANCE;
        private static volatile Parser<Landmark> PARSER = null;
        public static final int PRESENCE_FIELD_NUMBER = 5;
        public static final int VISIBILITY_FIELD_NUMBER = 4;
        public static final int X_FIELD_NUMBER = 1;
        public static final int Y_FIELD_NUMBER = 2;
        public static final int Z_FIELD_NUMBER = 3;
        private int bitField0_;
        private float presence_;
        private float visibility_;
        private float x_;
        private float y_;
        private float z_;

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

        private Landmark() {
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public boolean hasX() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
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

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public boolean hasY() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
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

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public boolean hasZ() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public float getZ() {
            return this.z_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setZ(float f) {
            this.bitField0_ |= 4;
            this.z_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearZ() {
            this.bitField0_ &= -5;
            this.z_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public boolean hasVisibility() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public float getVisibility() {
            return this.visibility_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setVisibility(float f) {
            this.bitField0_ |= 8;
            this.visibility_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearVisibility() {
            this.bitField0_ &= -9;
            this.visibility_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public boolean hasPresence() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
        public float getPresence() {
            return this.presence_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPresence(float f) {
            this.bitField0_ |= 16;
            this.presence_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPresence() {
            this.bitField0_ &= -17;
            this.presence_ = 0.0f;
        }

        public static Landmark parseFrom(ByteBuffer byteBuffer) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static Landmark parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static Landmark parseFrom(ByteString byteString) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static Landmark parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static Landmark parseFrom(byte[] bArr) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static Landmark parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static Landmark parseFrom(InputStream inputStream) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Landmark parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Landmark parseDelimitedFrom(InputStream inputStream) {
            return (Landmark) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static Landmark parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Landmark) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static Landmark parseFrom(CodedInputStream codedInputStream) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static Landmark parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (Landmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(Landmark landmark) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(landmark);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<Landmark, Builder> implements LandmarkOrBuilder {
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
                super(Landmark.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public boolean hasX() {
                return ((Landmark) this.instance).hasX();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public float getX() {
                return ((Landmark) this.instance).getX();
            }

            public Builder setX(float f) {
                copyOnWrite();
                ((Landmark) this.instance).setX(f);
                return this;
            }

            public Builder clearX() {
                copyOnWrite();
                ((Landmark) this.instance).clearX();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public boolean hasY() {
                return ((Landmark) this.instance).hasY();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public float getY() {
                return ((Landmark) this.instance).getY();
            }

            public Builder setY(float f) {
                copyOnWrite();
                ((Landmark) this.instance).setY(f);
                return this;
            }

            public Builder clearY() {
                copyOnWrite();
                ((Landmark) this.instance).clearY();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public boolean hasZ() {
                return ((Landmark) this.instance).hasZ();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public float getZ() {
                return ((Landmark) this.instance).getZ();
            }

            public Builder setZ(float f) {
                copyOnWrite();
                ((Landmark) this.instance).setZ(f);
                return this;
            }

            public Builder clearZ() {
                copyOnWrite();
                ((Landmark) this.instance).clearZ();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public boolean hasVisibility() {
                return ((Landmark) this.instance).hasVisibility();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public float getVisibility() {
                return ((Landmark) this.instance).getVisibility();
            }

            public Builder setVisibility(float f) {
                copyOnWrite();
                ((Landmark) this.instance).setVisibility(f);
                return this;
            }

            public Builder clearVisibility() {
                copyOnWrite();
                ((Landmark) this.instance).clearVisibility();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public boolean hasPresence() {
                return ((Landmark) this.instance).hasPresence();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkOrBuilder
            public float getPresence() {
                return ((Landmark) this.instance).getPresence();
            }

            public Builder setPresence(float f) {
                copyOnWrite();
                ((Landmark) this.instance).setPresence(f);
                return this;
            }

            public Builder clearPresence() {
                copyOnWrite();
                ((Landmark) this.instance).clearPresence();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new Landmark();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0005\u0000\u0001\u0001\u0005\u0005\u0000\u0000\u0000\u0001ခ\u0000\u0002ခ\u0001\u0003ခ\u0002\u0004ခ\u0003\u0005ခ\u0004", new Object[]{"bitField0_", "x_", "y_", "z_", "visibility_", "presence_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<Landmark> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (Landmark.class) {
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
            Landmark landmark = new Landmark();
            DEFAULT_INSTANCE = landmark;
            GeneratedMessageLite.registerDefaultInstance(Landmark.class, landmark);
        }

        public static Landmark getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<Landmark> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.formats.proto.LandmarkProto$1, reason: invalid class name */
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

    public static final class LandmarkList extends GeneratedMessageLite<LandmarkList, Builder> implements LandmarkListOrBuilder {
        private static final LandmarkList DEFAULT_INSTANCE;
        public static final int LANDMARK_FIELD_NUMBER = 1;
        private static volatile Parser<LandmarkList> PARSER;
        private Internal.ProtobufList<Landmark> landmark_ = GeneratedMessageLite.emptyProtobufList();

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

        private LandmarkList() {
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListOrBuilder
        public List<Landmark> getLandmarkList() {
            return this.landmark_;
        }

        public List<? extends LandmarkOrBuilder> getLandmarkOrBuilderList() {
            return this.landmark_;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListOrBuilder
        public int getLandmarkCount() {
            return this.landmark_.size();
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListOrBuilder
        public Landmark getLandmark(int i) {
            return this.landmark_.get(i);
        }

        public LandmarkOrBuilder getLandmarkOrBuilder(int i) {
            return this.landmark_.get(i);
        }

        private void ensureLandmarkIsMutable() {
            Internal.ProtobufList<Landmark> protobufList = this.landmark_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.landmark_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLandmark(int i, Landmark landmark) {
            landmark.getClass();
            ensureLandmarkIsMutable();
            this.landmark_.set(i, landmark);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmark(Landmark landmark) {
            landmark.getClass();
            ensureLandmarkIsMutable();
            this.landmark_.add(landmark);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmark(int i, Landmark landmark) {
            landmark.getClass();
            ensureLandmarkIsMutable();
            this.landmark_.add(i, landmark);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllLandmark(Iterable<? extends Landmark> iterable) {
            ensureLandmarkIsMutable();
            AbstractMessageLite.addAll(iterable, this.landmark_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLandmark() {
            this.landmark_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeLandmark(int i) {
            ensureLandmarkIsMutable();
            this.landmark_.remove(i);
        }

        public static LandmarkList parseFrom(ByteBuffer byteBuffer) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static LandmarkList parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static LandmarkList parseFrom(ByteString byteString) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static LandmarkList parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static LandmarkList parseFrom(byte[] bArr) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static LandmarkList parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static LandmarkList parseFrom(InputStream inputStream) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LandmarkList parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LandmarkList parseDelimitedFrom(InputStream inputStream) {
            return (LandmarkList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LandmarkList parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LandmarkList parseFrom(CodedInputStream codedInputStream) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static LandmarkList parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(LandmarkList landmarkList) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(landmarkList);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<LandmarkList, Builder> implements LandmarkListOrBuilder {
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
                super(LandmarkList.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListOrBuilder
            public List<Landmark> getLandmarkList() {
                return Collections.unmodifiableList(((LandmarkList) this.instance).getLandmarkList());
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListOrBuilder
            public int getLandmarkCount() {
                return ((LandmarkList) this.instance).getLandmarkCount();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListOrBuilder
            public Landmark getLandmark(int i) {
                return ((LandmarkList) this.instance).getLandmark(i);
            }

            public Builder setLandmark(int i, Landmark landmark) {
                copyOnWrite();
                ((LandmarkList) this.instance).setLandmark(i, landmark);
                return this;
            }

            public Builder setLandmark(int i, Landmark.Builder builder) {
                copyOnWrite();
                ((LandmarkList) this.instance).setLandmark(i, builder.build());
                return this;
            }

            public Builder addLandmark(Landmark landmark) {
                copyOnWrite();
                ((LandmarkList) this.instance).addLandmark(landmark);
                return this;
            }

            public Builder addLandmark(int i, Landmark landmark) {
                copyOnWrite();
                ((LandmarkList) this.instance).addLandmark(i, landmark);
                return this;
            }

            public Builder addLandmark(Landmark.Builder builder) {
                copyOnWrite();
                ((LandmarkList) this.instance).addLandmark(builder.build());
                return this;
            }

            public Builder addLandmark(int i, Landmark.Builder builder) {
                copyOnWrite();
                ((LandmarkList) this.instance).addLandmark(i, builder.build());
                return this;
            }

            public Builder addAllLandmark(Iterable<? extends Landmark> iterable) {
                copyOnWrite();
                ((LandmarkList) this.instance).addAllLandmark(iterable);
                return this;
            }

            public Builder clearLandmark() {
                copyOnWrite();
                ((LandmarkList) this.instance).clearLandmark();
                return this;
            }

            public Builder removeLandmark(int i) {
                copyOnWrite();
                ((LandmarkList) this.instance).removeLandmark(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new LandmarkList();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"landmark_", Landmark.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<LandmarkList> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (LandmarkList.class) {
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
            LandmarkList landmarkList = new LandmarkList();
            DEFAULT_INSTANCE = landmarkList;
            GeneratedMessageLite.registerDefaultInstance(LandmarkList.class, landmarkList);
        }

        public static LandmarkList getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<LandmarkList> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class LandmarkListCollection extends GeneratedMessageLite<LandmarkListCollection, Builder> implements LandmarkListCollectionOrBuilder {
        private static final LandmarkListCollection DEFAULT_INSTANCE;
        public static final int LANDMARK_LIST_FIELD_NUMBER = 1;
        private static volatile Parser<LandmarkListCollection> PARSER;
        private Internal.ProtobufList<LandmarkList> landmarkList_ = GeneratedMessageLite.emptyProtobufList();

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

        private LandmarkListCollection() {
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListCollectionOrBuilder
        public List<LandmarkList> getLandmarkListList() {
            return this.landmarkList_;
        }

        public List<? extends LandmarkListOrBuilder> getLandmarkListOrBuilderList() {
            return this.landmarkList_;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListCollectionOrBuilder
        public int getLandmarkListCount() {
            return this.landmarkList_.size();
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListCollectionOrBuilder
        public LandmarkList getLandmarkList(int i) {
            return this.landmarkList_.get(i);
        }

        public LandmarkListOrBuilder getLandmarkListOrBuilder(int i) {
            return this.landmarkList_.get(i);
        }

        private void ensureLandmarkListIsMutable() {
            Internal.ProtobufList<LandmarkList> protobufList = this.landmarkList_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.landmarkList_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLandmarkList(int i, LandmarkList landmarkList) {
            landmarkList.getClass();
            ensureLandmarkListIsMutable();
            this.landmarkList_.set(i, landmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmarkList(LandmarkList landmarkList) {
            landmarkList.getClass();
            ensureLandmarkListIsMutable();
            this.landmarkList_.add(landmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmarkList(int i, LandmarkList landmarkList) {
            landmarkList.getClass();
            ensureLandmarkListIsMutable();
            this.landmarkList_.add(i, landmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllLandmarkList(Iterable<? extends LandmarkList> iterable) {
            ensureLandmarkListIsMutable();
            AbstractMessageLite.addAll(iterable, this.landmarkList_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLandmarkList() {
            this.landmarkList_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeLandmarkList(int i) {
            ensureLandmarkListIsMutable();
            this.landmarkList_.remove(i);
        }

        public static LandmarkListCollection parseFrom(ByteBuffer byteBuffer) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static LandmarkListCollection parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static LandmarkListCollection parseFrom(ByteString byteString) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static LandmarkListCollection parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static LandmarkListCollection parseFrom(byte[] bArr) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static LandmarkListCollection parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static LandmarkListCollection parseFrom(InputStream inputStream) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LandmarkListCollection parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LandmarkListCollection parseDelimitedFrom(InputStream inputStream) {
            return (LandmarkListCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LandmarkListCollection parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkListCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LandmarkListCollection parseFrom(CodedInputStream codedInputStream) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static LandmarkListCollection parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(LandmarkListCollection landmarkListCollection) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(landmarkListCollection);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<LandmarkListCollection, Builder> implements LandmarkListCollectionOrBuilder {
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
                super(LandmarkListCollection.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListCollectionOrBuilder
            public List<LandmarkList> getLandmarkListList() {
                return Collections.unmodifiableList(((LandmarkListCollection) this.instance).getLandmarkListList());
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListCollectionOrBuilder
            public int getLandmarkListCount() {
                return ((LandmarkListCollection) this.instance).getLandmarkListCount();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.LandmarkListCollectionOrBuilder
            public LandmarkList getLandmarkList(int i) {
                return ((LandmarkListCollection) this.instance).getLandmarkList(i);
            }

            public Builder setLandmarkList(int i, LandmarkList landmarkList) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).setLandmarkList(i, landmarkList);
                return this;
            }

            public Builder setLandmarkList(int i, LandmarkList.Builder builder) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).setLandmarkList(i, builder.build());
                return this;
            }

            public Builder addLandmarkList(LandmarkList landmarkList) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).addLandmarkList(landmarkList);
                return this;
            }

            public Builder addLandmarkList(int i, LandmarkList landmarkList) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).addLandmarkList(i, landmarkList);
                return this;
            }

            public Builder addLandmarkList(LandmarkList.Builder builder) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).addLandmarkList(builder.build());
                return this;
            }

            public Builder addLandmarkList(int i, LandmarkList.Builder builder) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).addLandmarkList(i, builder.build());
                return this;
            }

            public Builder addAllLandmarkList(Iterable<? extends LandmarkList> iterable) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).addAllLandmarkList(iterable);
                return this;
            }

            public Builder clearLandmarkList() {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).clearLandmarkList();
                return this;
            }

            public Builder removeLandmarkList(int i) {
                copyOnWrite();
                ((LandmarkListCollection) this.instance).removeLandmarkList(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new LandmarkListCollection();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"landmarkList_", LandmarkList.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<LandmarkListCollection> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (LandmarkListCollection.class) {
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
            LandmarkListCollection landmarkListCollection = new LandmarkListCollection();
            DEFAULT_INSTANCE = landmarkListCollection;
            GeneratedMessageLite.registerDefaultInstance(LandmarkListCollection.class, landmarkListCollection);
        }

        public static LandmarkListCollection getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<LandmarkListCollection> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class NormalizedLandmark extends GeneratedMessageLite<NormalizedLandmark, Builder> implements NormalizedLandmarkOrBuilder {
        private static final NormalizedLandmark DEFAULT_INSTANCE;
        private static volatile Parser<NormalizedLandmark> PARSER = null;
        public static final int PRESENCE_FIELD_NUMBER = 5;
        public static final int VISIBILITY_FIELD_NUMBER = 4;
        public static final int X_FIELD_NUMBER = 1;
        public static final int Y_FIELD_NUMBER = 2;
        public static final int Z_FIELD_NUMBER = 3;
        private int bitField0_;
        private float presence_;
        private float visibility_;
        private float x_;
        private float y_;
        private float z_;

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

        private NormalizedLandmark() {
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public boolean hasX() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
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

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public boolean hasY() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
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

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public boolean hasZ() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public float getZ() {
            return this.z_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setZ(float f) {
            this.bitField0_ |= 4;
            this.z_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearZ() {
            this.bitField0_ &= -5;
            this.z_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public boolean hasVisibility() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public float getVisibility() {
            return this.visibility_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setVisibility(float f) {
            this.bitField0_ |= 8;
            this.visibility_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearVisibility() {
            this.bitField0_ &= -9;
            this.visibility_ = 0.0f;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public boolean hasPresence() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
        public float getPresence() {
            return this.presence_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPresence(float f) {
            this.bitField0_ |= 16;
            this.presence_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPresence() {
            this.bitField0_ &= -17;
            this.presence_ = 0.0f;
        }

        public static NormalizedLandmark parseFrom(ByteBuffer byteBuffer) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static NormalizedLandmark parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static NormalizedLandmark parseFrom(ByteString byteString) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static NormalizedLandmark parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static NormalizedLandmark parseFrom(byte[] bArr) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static NormalizedLandmark parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static NormalizedLandmark parseFrom(InputStream inputStream) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedLandmark parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedLandmark parseDelimitedFrom(InputStream inputStream) {
            return (NormalizedLandmark) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedLandmark parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmark) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedLandmark parseFrom(CodedInputStream codedInputStream) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static NormalizedLandmark parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmark) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(NormalizedLandmark normalizedLandmark) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(normalizedLandmark);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<NormalizedLandmark, Builder> implements NormalizedLandmarkOrBuilder {
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
                super(NormalizedLandmark.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public boolean hasX() {
                return ((NormalizedLandmark) this.instance).hasX();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public float getX() {
                return ((NormalizedLandmark) this.instance).getX();
            }

            public Builder setX(float f) {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).setX(f);
                return this;
            }

            public Builder clearX() {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).clearX();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public boolean hasY() {
                return ((NormalizedLandmark) this.instance).hasY();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public float getY() {
                return ((NormalizedLandmark) this.instance).getY();
            }

            public Builder setY(float f) {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).setY(f);
                return this;
            }

            public Builder clearY() {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).clearY();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public boolean hasZ() {
                return ((NormalizedLandmark) this.instance).hasZ();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public float getZ() {
                return ((NormalizedLandmark) this.instance).getZ();
            }

            public Builder setZ(float f) {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).setZ(f);
                return this;
            }

            public Builder clearZ() {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).clearZ();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public boolean hasVisibility() {
                return ((NormalizedLandmark) this.instance).hasVisibility();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public float getVisibility() {
                return ((NormalizedLandmark) this.instance).getVisibility();
            }

            public Builder setVisibility(float f) {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).setVisibility(f);
                return this;
            }

            public Builder clearVisibility() {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).clearVisibility();
                return this;
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public boolean hasPresence() {
                return ((NormalizedLandmark) this.instance).hasPresence();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkOrBuilder
            public float getPresence() {
                return ((NormalizedLandmark) this.instance).getPresence();
            }

            public Builder setPresence(float f) {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).setPresence(f);
                return this;
            }

            public Builder clearPresence() {
                copyOnWrite();
                ((NormalizedLandmark) this.instance).clearPresence();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new NormalizedLandmark();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0005\u0000\u0001\u0001\u0005\u0005\u0000\u0000\u0000\u0001ခ\u0000\u0002ခ\u0001\u0003ခ\u0002\u0004ခ\u0003\u0005ခ\u0004", new Object[]{"bitField0_", "x_", "y_", "z_", "visibility_", "presence_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<NormalizedLandmark> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (NormalizedLandmark.class) {
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
            NormalizedLandmark normalizedLandmark = new NormalizedLandmark();
            DEFAULT_INSTANCE = normalizedLandmark;
            GeneratedMessageLite.registerDefaultInstance(NormalizedLandmark.class, normalizedLandmark);
        }

        public static NormalizedLandmark getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<NormalizedLandmark> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class NormalizedLandmarkList extends GeneratedMessageLite<NormalizedLandmarkList, Builder> implements NormalizedLandmarkListOrBuilder {
        private static final NormalizedLandmarkList DEFAULT_INSTANCE;
        public static final int LANDMARK_FIELD_NUMBER = 1;
        private static volatile Parser<NormalizedLandmarkList> PARSER;
        private Internal.ProtobufList<NormalizedLandmark> landmark_ = GeneratedMessageLite.emptyProtobufList();

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

        private NormalizedLandmarkList() {
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListOrBuilder
        public List<NormalizedLandmark> getLandmarkList() {
            return this.landmark_;
        }

        public List<? extends NormalizedLandmarkOrBuilder> getLandmarkOrBuilderList() {
            return this.landmark_;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListOrBuilder
        public int getLandmarkCount() {
            return this.landmark_.size();
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListOrBuilder
        public NormalizedLandmark getLandmark(int i) {
            return this.landmark_.get(i);
        }

        public NormalizedLandmarkOrBuilder getLandmarkOrBuilder(int i) {
            return this.landmark_.get(i);
        }

        private void ensureLandmarkIsMutable() {
            Internal.ProtobufList<NormalizedLandmark> protobufList = this.landmark_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.landmark_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLandmark(int i, NormalizedLandmark normalizedLandmark) {
            normalizedLandmark.getClass();
            ensureLandmarkIsMutable();
            this.landmark_.set(i, normalizedLandmark);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmark(NormalizedLandmark normalizedLandmark) {
            normalizedLandmark.getClass();
            ensureLandmarkIsMutable();
            this.landmark_.add(normalizedLandmark);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmark(int i, NormalizedLandmark normalizedLandmark) {
            normalizedLandmark.getClass();
            ensureLandmarkIsMutable();
            this.landmark_.add(i, normalizedLandmark);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllLandmark(Iterable<? extends NormalizedLandmark> iterable) {
            ensureLandmarkIsMutable();
            AbstractMessageLite.addAll(iterable, this.landmark_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLandmark() {
            this.landmark_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeLandmark(int i) {
            ensureLandmarkIsMutable();
            this.landmark_.remove(i);
        }

        public static NormalizedLandmarkList parseFrom(ByteBuffer byteBuffer) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static NormalizedLandmarkList parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static NormalizedLandmarkList parseFrom(ByteString byteString) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static NormalizedLandmarkList parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static NormalizedLandmarkList parseFrom(byte[] bArr) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static NormalizedLandmarkList parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static NormalizedLandmarkList parseFrom(InputStream inputStream) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedLandmarkList parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedLandmarkList parseDelimitedFrom(InputStream inputStream) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedLandmarkList parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedLandmarkList parseFrom(CodedInputStream codedInputStream) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static NormalizedLandmarkList parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkList) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(NormalizedLandmarkList normalizedLandmarkList) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(normalizedLandmarkList);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<NormalizedLandmarkList, Builder> implements NormalizedLandmarkListOrBuilder {
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
                super(NormalizedLandmarkList.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListOrBuilder
            public List<NormalizedLandmark> getLandmarkList() {
                return Collections.unmodifiableList(((NormalizedLandmarkList) this.instance).getLandmarkList());
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListOrBuilder
            public int getLandmarkCount() {
                return ((NormalizedLandmarkList) this.instance).getLandmarkCount();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListOrBuilder
            public NormalizedLandmark getLandmark(int i) {
                return ((NormalizedLandmarkList) this.instance).getLandmark(i);
            }

            public Builder setLandmark(int i, NormalizedLandmark normalizedLandmark) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).setLandmark(i, normalizedLandmark);
                return this;
            }

            public Builder setLandmark(int i, NormalizedLandmark.Builder builder) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).setLandmark(i, builder.build());
                return this;
            }

            public Builder addLandmark(NormalizedLandmark normalizedLandmark) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).addLandmark(normalizedLandmark);
                return this;
            }

            public Builder addLandmark(int i, NormalizedLandmark normalizedLandmark) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).addLandmark(i, normalizedLandmark);
                return this;
            }

            public Builder addLandmark(NormalizedLandmark.Builder builder) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).addLandmark(builder.build());
                return this;
            }

            public Builder addLandmark(int i, NormalizedLandmark.Builder builder) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).addLandmark(i, builder.build());
                return this;
            }

            public Builder addAllLandmark(Iterable<? extends NormalizedLandmark> iterable) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).addAllLandmark(iterable);
                return this;
            }

            public Builder clearLandmark() {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).clearLandmark();
                return this;
            }

            public Builder removeLandmark(int i) {
                copyOnWrite();
                ((NormalizedLandmarkList) this.instance).removeLandmark(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new NormalizedLandmarkList();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"landmark_", NormalizedLandmark.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<NormalizedLandmarkList> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (NormalizedLandmarkList.class) {
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
            NormalizedLandmarkList normalizedLandmarkList = new NormalizedLandmarkList();
            DEFAULT_INSTANCE = normalizedLandmarkList;
            GeneratedMessageLite.registerDefaultInstance(NormalizedLandmarkList.class, normalizedLandmarkList);
        }

        public static NormalizedLandmarkList getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<NormalizedLandmarkList> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class NormalizedLandmarkListCollection extends GeneratedMessageLite<NormalizedLandmarkListCollection, Builder> implements NormalizedLandmarkListCollectionOrBuilder {
        private static final NormalizedLandmarkListCollection DEFAULT_INSTANCE;
        public static final int LANDMARK_LIST_FIELD_NUMBER = 1;
        private static volatile Parser<NormalizedLandmarkListCollection> PARSER;
        private Internal.ProtobufList<NormalizedLandmarkList> landmarkList_ = GeneratedMessageLite.emptyProtobufList();

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

        private NormalizedLandmarkListCollection() {
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListCollectionOrBuilder
        public List<NormalizedLandmarkList> getLandmarkListList() {
            return this.landmarkList_;
        }

        public List<? extends NormalizedLandmarkListOrBuilder> getLandmarkListOrBuilderList() {
            return this.landmarkList_;
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListCollectionOrBuilder
        public int getLandmarkListCount() {
            return this.landmarkList_.size();
        }

        @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListCollectionOrBuilder
        public NormalizedLandmarkList getLandmarkList(int i) {
            return this.landmarkList_.get(i);
        }

        public NormalizedLandmarkListOrBuilder getLandmarkListOrBuilder(int i) {
            return this.landmarkList_.get(i);
        }

        private void ensureLandmarkListIsMutable() {
            Internal.ProtobufList<NormalizedLandmarkList> protobufList = this.landmarkList_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.landmarkList_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLandmarkList(int i, NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            ensureLandmarkListIsMutable();
            this.landmarkList_.set(i, normalizedLandmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmarkList(NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            ensureLandmarkListIsMutable();
            this.landmarkList_.add(normalizedLandmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addLandmarkList(int i, NormalizedLandmarkList normalizedLandmarkList) {
            normalizedLandmarkList.getClass();
            ensureLandmarkListIsMutable();
            this.landmarkList_.add(i, normalizedLandmarkList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllLandmarkList(Iterable<? extends NormalizedLandmarkList> iterable) {
            ensureLandmarkListIsMutable();
            AbstractMessageLite.addAll(iterable, this.landmarkList_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLandmarkList() {
            this.landmarkList_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeLandmarkList(int i) {
            ensureLandmarkListIsMutable();
            this.landmarkList_.remove(i);
        }

        public static NormalizedLandmarkListCollection parseFrom(ByteBuffer byteBuffer) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static NormalizedLandmarkListCollection parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static NormalizedLandmarkListCollection parseFrom(ByteString byteString) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static NormalizedLandmarkListCollection parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static NormalizedLandmarkListCollection parseFrom(byte[] bArr) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static NormalizedLandmarkListCollection parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static NormalizedLandmarkListCollection parseFrom(InputStream inputStream) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedLandmarkListCollection parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedLandmarkListCollection parseDelimitedFrom(InputStream inputStream) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static NormalizedLandmarkListCollection parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static NormalizedLandmarkListCollection parseFrom(CodedInputStream codedInputStream) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static NormalizedLandmarkListCollection parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (NormalizedLandmarkListCollection) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(NormalizedLandmarkListCollection normalizedLandmarkListCollection) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(normalizedLandmarkListCollection);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<NormalizedLandmarkListCollection, Builder> implements NormalizedLandmarkListCollectionOrBuilder {
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
                super(NormalizedLandmarkListCollection.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListCollectionOrBuilder
            public List<NormalizedLandmarkList> getLandmarkListList() {
                return Collections.unmodifiableList(((NormalizedLandmarkListCollection) this.instance).getLandmarkListList());
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListCollectionOrBuilder
            public int getLandmarkListCount() {
                return ((NormalizedLandmarkListCollection) this.instance).getLandmarkListCount();
            }

            @Override // com.google.mediapipe.formats.proto.LandmarkProto.NormalizedLandmarkListCollectionOrBuilder
            public NormalizedLandmarkList getLandmarkList(int i) {
                return ((NormalizedLandmarkListCollection) this.instance).getLandmarkList(i);
            }

            public Builder setLandmarkList(int i, NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).setLandmarkList(i, normalizedLandmarkList);
                return this;
            }

            public Builder setLandmarkList(int i, NormalizedLandmarkList.Builder builder) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).setLandmarkList(i, builder.build());
                return this;
            }

            public Builder addLandmarkList(NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).addLandmarkList(normalizedLandmarkList);
                return this;
            }

            public Builder addLandmarkList(int i, NormalizedLandmarkList normalizedLandmarkList) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).addLandmarkList(i, normalizedLandmarkList);
                return this;
            }

            public Builder addLandmarkList(NormalizedLandmarkList.Builder builder) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).addLandmarkList(builder.build());
                return this;
            }

            public Builder addLandmarkList(int i, NormalizedLandmarkList.Builder builder) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).addLandmarkList(i, builder.build());
                return this;
            }

            public Builder addAllLandmarkList(Iterable<? extends NormalizedLandmarkList> iterable) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).addAllLandmarkList(iterable);
                return this;
            }

            public Builder clearLandmarkList() {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).clearLandmarkList();
                return this;
            }

            public Builder removeLandmarkList(int i) {
                copyOnWrite();
                ((NormalizedLandmarkListCollection) this.instance).removeLandmarkList(i);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new NormalizedLandmarkListCollection();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"landmarkList_", NormalizedLandmarkList.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<NormalizedLandmarkListCollection> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (NormalizedLandmarkListCollection.class) {
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
            NormalizedLandmarkListCollection normalizedLandmarkListCollection = new NormalizedLandmarkListCollection();
            DEFAULT_INSTANCE = normalizedLandmarkListCollection;
            GeneratedMessageLite.registerDefaultInstance(NormalizedLandmarkListCollection.class, normalizedLandmarkListCollection);
        }

        public static NormalizedLandmarkListCollection getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<NormalizedLandmarkListCollection> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
