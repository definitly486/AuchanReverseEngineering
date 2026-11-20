package com.google.mediapipe.util.proto;

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
public final class LabelMapProto {

    public interface LabelMapItemOrBuilder extends MessageLiteOrBuilder {
        String getChildName(int i);

        ByteString getChildNameBytes(int i);

        int getChildNameCount();

        List<String> getChildNameList();

        String getDisplayName();

        ByteString getDisplayNameBytes();

        String getName();

        ByteString getNameBytes();

        boolean hasDisplayName();

        boolean hasName();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private LabelMapProto() {
    }

    public static final class LabelMapItem extends GeneratedMessageLite<LabelMapItem, Builder> implements LabelMapItemOrBuilder {
        public static final int CHILD_NAME_FIELD_NUMBER = 3;
        private static final LabelMapItem DEFAULT_INSTANCE;
        public static final int DISPLAY_NAME_FIELD_NUMBER = 2;
        public static final int NAME_FIELD_NUMBER = 1;
        private static volatile Parser<LabelMapItem> PARSER;
        private int bitField0_;
        private String name_ = "";
        private String displayName_ = "";
        private Internal.ProtobufList<String> childName_ = GeneratedMessageLite.emptyProtobufList();

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

        private LabelMapItem() {
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public boolean hasName() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public String getName() {
            return this.name_;
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public ByteString getNameBytes() {
            return ByteString.copyFromUtf8(this.name_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setName(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.name_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearName() {
            this.bitField0_ &= -2;
            this.name_ = getDefaultInstance().getName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setNameBytes(ByteString byteString) {
            this.name_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public boolean hasDisplayName() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public String getDisplayName() {
            return this.displayName_;
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public ByteString getDisplayNameBytes() {
            return ByteString.copyFromUtf8(this.displayName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayName(String str) {
            str.getClass();
            this.bitField0_ |= 2;
            this.displayName_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearDisplayName() {
            this.bitField0_ &= -3;
            this.displayName_ = getDefaultInstance().getDisplayName();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setDisplayNameBytes(ByteString byteString) {
            this.displayName_ = byteString.toStringUtf8();
            this.bitField0_ |= 2;
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public List<String> getChildNameList() {
            return this.childName_;
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public int getChildNameCount() {
            return this.childName_.size();
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public String getChildName(int i) {
            return this.childName_.get(i);
        }

        @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
        public ByteString getChildNameBytes(int i) {
            return ByteString.copyFromUtf8(this.childName_.get(i));
        }

        private void ensureChildNameIsMutable() {
            Internal.ProtobufList<String> protobufList = this.childName_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.childName_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setChildName(int i, String str) {
            str.getClass();
            ensureChildNameIsMutable();
            this.childName_.set(i, str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addChildName(String str) {
            str.getClass();
            ensureChildNameIsMutable();
            this.childName_.add(str);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllChildName(Iterable<String> iterable) {
            ensureChildNameIsMutable();
            AbstractMessageLite.addAll(iterable, this.childName_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearChildName() {
            this.childName_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addChildNameBytes(ByteString byteString) {
            ensureChildNameIsMutable();
            this.childName_.add(byteString.toStringUtf8());
        }

        public static LabelMapItem parseFrom(ByteBuffer byteBuffer) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static LabelMapItem parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static LabelMapItem parseFrom(ByteString byteString) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static LabelMapItem parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static LabelMapItem parseFrom(byte[] bArr) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static LabelMapItem parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static LabelMapItem parseFrom(InputStream inputStream) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LabelMapItem parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LabelMapItem parseDelimitedFrom(InputStream inputStream) {
            return (LabelMapItem) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static LabelMapItem parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LabelMapItem) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static LabelMapItem parseFrom(CodedInputStream codedInputStream) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static LabelMapItem parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (LabelMapItem) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(LabelMapItem labelMapItem) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(labelMapItem);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<LabelMapItem, Builder> implements LabelMapItemOrBuilder {
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
                super(LabelMapItem.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public boolean hasName() {
                return ((LabelMapItem) this.instance).hasName();
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public String getName() {
                return ((LabelMapItem) this.instance).getName();
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public ByteString getNameBytes() {
                return ((LabelMapItem) this.instance).getNameBytes();
            }

            public Builder setName(String str) {
                copyOnWrite();
                ((LabelMapItem) this.instance).setName(str);
                return this;
            }

            public Builder clearName() {
                copyOnWrite();
                ((LabelMapItem) this.instance).clearName();
                return this;
            }

            public Builder setNameBytes(ByteString byteString) {
                copyOnWrite();
                ((LabelMapItem) this.instance).setNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public boolean hasDisplayName() {
                return ((LabelMapItem) this.instance).hasDisplayName();
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public String getDisplayName() {
                return ((LabelMapItem) this.instance).getDisplayName();
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public ByteString getDisplayNameBytes() {
                return ((LabelMapItem) this.instance).getDisplayNameBytes();
            }

            public Builder setDisplayName(String str) {
                copyOnWrite();
                ((LabelMapItem) this.instance).setDisplayName(str);
                return this;
            }

            public Builder clearDisplayName() {
                copyOnWrite();
                ((LabelMapItem) this.instance).clearDisplayName();
                return this;
            }

            public Builder setDisplayNameBytes(ByteString byteString) {
                copyOnWrite();
                ((LabelMapItem) this.instance).setDisplayNameBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public List<String> getChildNameList() {
                return Collections.unmodifiableList(((LabelMapItem) this.instance).getChildNameList());
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public int getChildNameCount() {
                return ((LabelMapItem) this.instance).getChildNameCount();
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public String getChildName(int i) {
                return ((LabelMapItem) this.instance).getChildName(i);
            }

            @Override // com.google.mediapipe.util.proto.LabelMapProto.LabelMapItemOrBuilder
            public ByteString getChildNameBytes(int i) {
                return ((LabelMapItem) this.instance).getChildNameBytes(i);
            }

            public Builder setChildName(int i, String str) {
                copyOnWrite();
                ((LabelMapItem) this.instance).setChildName(i, str);
                return this;
            }

            public Builder addChildName(String str) {
                copyOnWrite();
                ((LabelMapItem) this.instance).addChildName(str);
                return this;
            }

            public Builder addAllChildName(Iterable<String> iterable) {
                copyOnWrite();
                ((LabelMapItem) this.instance).addAllChildName(iterable);
                return this;
            }

            public Builder clearChildName() {
                copyOnWrite();
                ((LabelMapItem) this.instance).clearChildName();
                return this;
            }

            public Builder addChildNameBytes(ByteString byteString) {
                copyOnWrite();
                ((LabelMapItem) this.instance).addChildNameBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new LabelMapItem();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0001\u0000\u0001ဈ\u0000\u0002ဈ\u0001\u0003\u001a", new Object[]{"bitField0_", "name_", "displayName_", "childName_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<LabelMapItem> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (LabelMapItem.class) {
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
            LabelMapItem labelMapItem = new LabelMapItem();
            DEFAULT_INSTANCE = labelMapItem;
            GeneratedMessageLite.registerDefaultInstance(LabelMapItem.class, labelMapItem);
        }

        public static LabelMapItem getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<LabelMapItem> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.util.proto.LabelMapProto$1, reason: invalid class name */
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
