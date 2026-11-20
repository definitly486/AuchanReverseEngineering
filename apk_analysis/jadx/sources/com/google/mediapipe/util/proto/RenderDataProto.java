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
public final class RenderDataProto {

    public interface RenderAnnotationOrBuilder extends MessageLiteOrBuilder {
        RenderAnnotation.Arrow getArrow();

        ColorProto.Color getColor();

        RenderAnnotation.DataCase getDataCase();

        RenderAnnotation.FilledOval getFilledOval();

        RenderAnnotation.FilledRectangle getFilledRectangle();

        RenderAnnotation.FilledRoundedRectangle getFilledRoundedRectangle();

        RenderAnnotation.GradientLine getGradientLine();

        RenderAnnotation.Line getLine();

        RenderAnnotation.Oval getOval();

        RenderAnnotation.Point getPoint();

        RenderAnnotation.Rectangle getRectangle();

        RenderAnnotation.RoundedRectangle getRoundedRectangle();

        String getSceneTag();

        ByteString getSceneTagBytes();

        RenderAnnotation.Scribble getScribble();

        RenderAnnotation.Text getText();

        double getThickness();

        boolean hasArrow();

        boolean hasColor();

        boolean hasFilledOval();

        boolean hasFilledRectangle();

        boolean hasFilledRoundedRectangle();

        boolean hasGradientLine();

        boolean hasLine();

        boolean hasOval();

        boolean hasPoint();

        boolean hasRectangle();

        boolean hasRoundedRectangle();

        boolean hasSceneTag();

        boolean hasScribble();

        boolean hasText();

        boolean hasThickness();
    }

    public interface RenderDataOrBuilder extends MessageLiteOrBuilder {
        RenderAnnotation getRenderAnnotations(int i);

        int getRenderAnnotationsCount();

        List<RenderAnnotation> getRenderAnnotationsList();

        String getSceneClass();

        ByteString getSceneClassBytes();

        RenderViewport getSceneViewport();

        boolean hasSceneClass();

        boolean hasSceneViewport();
    }

    public interface RenderViewportOrBuilder extends MessageLiteOrBuilder {
        boolean getComposeOnVideo();

        int getHeightPx();

        String getId();

        ByteString getIdBytes();

        int getWidthPx();

        boolean hasComposeOnVideo();

        boolean hasHeightPx();

        boolean hasId();

        boolean hasWidthPx();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private RenderDataProto() {
    }

    public static final class RenderData extends GeneratedMessageLite<RenderData, Builder> implements RenderDataOrBuilder {
        private static final RenderData DEFAULT_INSTANCE;
        private static volatile Parser<RenderData> PARSER = null;
        public static final int RENDER_ANNOTATIONS_FIELD_NUMBER = 1;
        public static final int SCENE_CLASS_FIELD_NUMBER = 2;
        public static final int SCENE_VIEWPORT_FIELD_NUMBER = 3;
        private int bitField0_;
        private Internal.ProtobufList<RenderAnnotation> renderAnnotations_ = GeneratedMessageLite.emptyProtobufList();
        private String sceneClass_ = "";
        private RenderViewport sceneViewport_;

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

        private RenderData() {
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public List<RenderAnnotation> getRenderAnnotationsList() {
            return this.renderAnnotations_;
        }

        public List<? extends RenderAnnotationOrBuilder> getRenderAnnotationsOrBuilderList() {
            return this.renderAnnotations_;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public int getRenderAnnotationsCount() {
            return this.renderAnnotations_.size();
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public RenderAnnotation getRenderAnnotations(int i) {
            return this.renderAnnotations_.get(i);
        }

        public RenderAnnotationOrBuilder getRenderAnnotationsOrBuilder(int i) {
            return this.renderAnnotations_.get(i);
        }

        private void ensureRenderAnnotationsIsMutable() {
            Internal.ProtobufList<RenderAnnotation> protobufList = this.renderAnnotations_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.renderAnnotations_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRenderAnnotations(int i, RenderAnnotation renderAnnotation) {
            renderAnnotation.getClass();
            ensureRenderAnnotationsIsMutable();
            this.renderAnnotations_.set(i, renderAnnotation);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addRenderAnnotations(RenderAnnotation renderAnnotation) {
            renderAnnotation.getClass();
            ensureRenderAnnotationsIsMutable();
            this.renderAnnotations_.add(renderAnnotation);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addRenderAnnotations(int i, RenderAnnotation renderAnnotation) {
            renderAnnotation.getClass();
            ensureRenderAnnotationsIsMutable();
            this.renderAnnotations_.add(i, renderAnnotation);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllRenderAnnotations(Iterable<? extends RenderAnnotation> iterable) {
            ensureRenderAnnotationsIsMutable();
            AbstractMessageLite.addAll(iterable, this.renderAnnotations_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRenderAnnotations() {
            this.renderAnnotations_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeRenderAnnotations(int i) {
            ensureRenderAnnotationsIsMutable();
            this.renderAnnotations_.remove(i);
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public boolean hasSceneClass() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public String getSceneClass() {
            return this.sceneClass_;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public ByteString getSceneClassBytes() {
            return ByteString.copyFromUtf8(this.sceneClass_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setSceneClass(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.sceneClass_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearSceneClass() {
            this.bitField0_ &= -2;
            this.sceneClass_ = getDefaultInstance().getSceneClass();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setSceneClassBytes(ByteString byteString) {
            this.sceneClass_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public boolean hasSceneViewport() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
        public RenderViewport getSceneViewport() {
            RenderViewport renderViewport = this.sceneViewport_;
            return renderViewport == null ? RenderViewport.getDefaultInstance() : renderViewport;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setSceneViewport(RenderViewport renderViewport) {
            renderViewport.getClass();
            this.sceneViewport_ = renderViewport;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeSceneViewport(RenderViewport renderViewport) {
            renderViewport.getClass();
            RenderViewport renderViewport2 = this.sceneViewport_;
            if (renderViewport2 != null && renderViewport2 != RenderViewport.getDefaultInstance()) {
                this.sceneViewport_ = RenderViewport.newBuilder(this.sceneViewport_).mergeFrom(renderViewport).buildPartial();
            } else {
                this.sceneViewport_ = renderViewport;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearSceneViewport() {
            this.sceneViewport_ = null;
            this.bitField0_ &= -3;
        }

        public static RenderData parseFrom(ByteBuffer byteBuffer) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static RenderData parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static RenderData parseFrom(ByteString byteString) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static RenderData parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static RenderData parseFrom(byte[] bArr) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static RenderData parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static RenderData parseFrom(InputStream inputStream) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RenderData parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RenderData parseDelimitedFrom(InputStream inputStream) {
            return (RenderData) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RenderData parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderData) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RenderData parseFrom(CodedInputStream codedInputStream) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static RenderData parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderData) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(RenderData renderData) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(renderData);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<RenderData, Builder> implements RenderDataOrBuilder {
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
                super(RenderData.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public List<RenderAnnotation> getRenderAnnotationsList() {
                return Collections.unmodifiableList(((RenderData) this.instance).getRenderAnnotationsList());
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public int getRenderAnnotationsCount() {
                return ((RenderData) this.instance).getRenderAnnotationsCount();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public RenderAnnotation getRenderAnnotations(int i) {
                return ((RenderData) this.instance).getRenderAnnotations(i);
            }

            public Builder setRenderAnnotations(int i, RenderAnnotation renderAnnotation) {
                copyOnWrite();
                ((RenderData) this.instance).setRenderAnnotations(i, renderAnnotation);
                return this;
            }

            public Builder setRenderAnnotations(int i, RenderAnnotation.Builder builder) {
                copyOnWrite();
                ((RenderData) this.instance).setRenderAnnotations(i, builder.build());
                return this;
            }

            public Builder addRenderAnnotations(RenderAnnotation renderAnnotation) {
                copyOnWrite();
                ((RenderData) this.instance).addRenderAnnotations(renderAnnotation);
                return this;
            }

            public Builder addRenderAnnotations(int i, RenderAnnotation renderAnnotation) {
                copyOnWrite();
                ((RenderData) this.instance).addRenderAnnotations(i, renderAnnotation);
                return this;
            }

            public Builder addRenderAnnotations(RenderAnnotation.Builder builder) {
                copyOnWrite();
                ((RenderData) this.instance).addRenderAnnotations(builder.build());
                return this;
            }

            public Builder addRenderAnnotations(int i, RenderAnnotation.Builder builder) {
                copyOnWrite();
                ((RenderData) this.instance).addRenderAnnotations(i, builder.build());
                return this;
            }

            public Builder addAllRenderAnnotations(Iterable<? extends RenderAnnotation> iterable) {
                copyOnWrite();
                ((RenderData) this.instance).addAllRenderAnnotations(iterable);
                return this;
            }

            public Builder clearRenderAnnotations() {
                copyOnWrite();
                ((RenderData) this.instance).clearRenderAnnotations();
                return this;
            }

            public Builder removeRenderAnnotations(int i) {
                copyOnWrite();
                ((RenderData) this.instance).removeRenderAnnotations(i);
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public boolean hasSceneClass() {
                return ((RenderData) this.instance).hasSceneClass();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public String getSceneClass() {
                return ((RenderData) this.instance).getSceneClass();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public ByteString getSceneClassBytes() {
                return ((RenderData) this.instance).getSceneClassBytes();
            }

            public Builder setSceneClass(String str) {
                copyOnWrite();
                ((RenderData) this.instance).setSceneClass(str);
                return this;
            }

            public Builder clearSceneClass() {
                copyOnWrite();
                ((RenderData) this.instance).clearSceneClass();
                return this;
            }

            public Builder setSceneClassBytes(ByteString byteString) {
                copyOnWrite();
                ((RenderData) this.instance).setSceneClassBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public boolean hasSceneViewport() {
                return ((RenderData) this.instance).hasSceneViewport();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderDataOrBuilder
            public RenderViewport getSceneViewport() {
                return ((RenderData) this.instance).getSceneViewport();
            }

            public Builder setSceneViewport(RenderViewport renderViewport) {
                copyOnWrite();
                ((RenderData) this.instance).setSceneViewport(renderViewport);
                return this;
            }

            public Builder setSceneViewport(RenderViewport.Builder builder) {
                copyOnWrite();
                ((RenderData) this.instance).setSceneViewport(builder.build());
                return this;
            }

            public Builder mergeSceneViewport(RenderViewport renderViewport) {
                copyOnWrite();
                ((RenderData) this.instance).mergeSceneViewport(renderViewport);
                return this;
            }

            public Builder clearSceneViewport() {
                copyOnWrite();
                ((RenderData) this.instance).clearSceneViewport();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new RenderData();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0001\u0000\u0001\u001b\u0002ဈ\u0000\u0003ဉ\u0001", new Object[]{"bitField0_", "renderAnnotations_", RenderAnnotation.class, "sceneClass_", "sceneViewport_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<RenderData> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (RenderData.class) {
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
            RenderData renderData = new RenderData();
            DEFAULT_INSTANCE = renderData;
            GeneratedMessageLite.registerDefaultInstance(RenderData.class, renderData);
        }

        public static RenderData getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<RenderData> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.util.proto.RenderDataProto$1, reason: invalid class name */
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

    public static final class RenderAnnotation extends GeneratedMessageLite<RenderAnnotation, Builder> implements RenderAnnotationOrBuilder {
        public static final int ARROW_FIELD_NUMBER = 7;
        public static final int COLOR_FIELD_NUMBER = 12;
        private static final RenderAnnotation DEFAULT_INSTANCE;
        public static final int FILLED_OVAL_FIELD_NUMBER = 4;
        public static final int FILLED_RECTANGLE_FIELD_NUMBER = 2;
        public static final int FILLED_ROUNDED_RECTANGLE_FIELD_NUMBER = 10;
        public static final int GRADIENT_LINE_FIELD_NUMBER = 14;
        public static final int LINE_FIELD_NUMBER = 6;
        public static final int OVAL_FIELD_NUMBER = 3;
        private static volatile Parser<RenderAnnotation> PARSER = null;
        public static final int POINT_FIELD_NUMBER = 5;
        public static final int RECTANGLE_FIELD_NUMBER = 1;
        public static final int ROUNDED_RECTANGLE_FIELD_NUMBER = 9;
        public static final int SCENE_TAG_FIELD_NUMBER = 13;
        public static final int SCRIBBLE_FIELD_NUMBER = 15;
        public static final int TEXT_FIELD_NUMBER = 8;
        public static final int THICKNESS_FIELD_NUMBER = 11;
        private int bitField0_;
        private ColorProto.Color color_;
        private Object data_;
        private int dataCase_ = 0;
        private double thickness_ = 1.0d;
        private String sceneTag_ = "";

        public interface ArrowOrBuilder extends MessageLiteOrBuilder {
            boolean getNormalized();

            double getXEnd();

            double getXStart();

            double getYEnd();

            double getYStart();

            boolean hasNormalized();

            boolean hasXEnd();

            boolean hasXStart();

            boolean hasYEnd();

            boolean hasYStart();
        }

        public interface FilledOvalOrBuilder extends MessageLiteOrBuilder {
            ColorProto.Color getFillColor();

            Oval getOval();

            boolean hasFillColor();

            boolean hasOval();
        }

        public interface FilledRectangleOrBuilder extends MessageLiteOrBuilder {
            ColorProto.Color getFillColor();

            Rectangle getRectangle();

            boolean hasFillColor();

            boolean hasRectangle();
        }

        public interface FilledRoundedRectangleOrBuilder extends MessageLiteOrBuilder {
            ColorProto.Color getFillColor();

            RoundedRectangle getRoundedRectangle();

            boolean hasFillColor();

            boolean hasRoundedRectangle();
        }

        public interface GradientLineOrBuilder extends MessageLiteOrBuilder {
            ColorProto.Color getColor1();

            ColorProto.Color getColor2();

            boolean getNormalized();

            double getXEnd();

            double getXStart();

            double getYEnd();

            double getYStart();

            boolean hasColor1();

            boolean hasColor2();

            boolean hasNormalized();

            boolean hasXEnd();

            boolean hasXStart();

            boolean hasYEnd();

            boolean hasYStart();
        }

        public interface LineOrBuilder extends MessageLiteOrBuilder {
            Line.LineType getLineType();

            boolean getNormalized();

            double getXEnd();

            double getXStart();

            double getYEnd();

            double getYStart();

            boolean hasLineType();

            boolean hasNormalized();

            boolean hasXEnd();

            boolean hasXStart();

            boolean hasYEnd();

            boolean hasYStart();
        }

        public interface OvalOrBuilder extends MessageLiteOrBuilder {
            Rectangle getRectangle();

            boolean hasRectangle();
        }

        public interface PointOrBuilder extends MessageLiteOrBuilder {
            boolean getNormalized();

            double getX();

            double getY();

            boolean hasNormalized();

            boolean hasX();

            boolean hasY();
        }

        public interface RectangleOrBuilder extends MessageLiteOrBuilder {
            double getBottom();

            double getLeft();

            boolean getNormalized();

            double getRight();

            double getRotation();

            double getTop();

            double getTopLeftThickness();

            boolean hasBottom();

            boolean hasLeft();

            boolean hasNormalized();

            boolean hasRight();

            boolean hasRotation();

            boolean hasTop();

            boolean hasTopLeftThickness();
        }

        public interface RoundedRectangleOrBuilder extends MessageLiteOrBuilder {
            int getCornerRadius();

            int getLineType();

            Rectangle getRectangle();

            boolean hasCornerRadius();

            boolean hasLineType();

            boolean hasRectangle();
        }

        public interface ScribbleOrBuilder extends MessageLiteOrBuilder {
            Point getPoint(int i);

            int getPointCount();

            List<Point> getPointList();
        }

        public interface TextOrBuilder extends MessageLiteOrBuilder {
            double getBaseline();

            boolean getCenterHorizontally();

            boolean getCenterVertically();

            String getDisplayText();

            ByteString getDisplayTextBytes();

            int getFontFace();

            double getFontHeight();

            double getLeft();

            boolean getNormalized();

            ColorProto.Color getOutlineColor();

            double getOutlineThickness();

            boolean hasBaseline();

            boolean hasCenterHorizontally();

            boolean hasCenterVertically();

            boolean hasDisplayText();

            boolean hasFontFace();

            boolean hasFontHeight();

            boolean hasLeft();

            boolean hasNormalized();

            boolean hasOutlineColor();

            boolean hasOutlineThickness();
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

        private RenderAnnotation() {
        }

        public static final class Rectangle extends GeneratedMessageLite<Rectangle, Builder> implements RectangleOrBuilder {
            public static final int BOTTOM_FIELD_NUMBER = 4;
            private static final Rectangle DEFAULT_INSTANCE;
            public static final int LEFT_FIELD_NUMBER = 1;
            public static final int NORMALIZED_FIELD_NUMBER = 5;
            private static volatile Parser<Rectangle> PARSER = null;
            public static final int RIGHT_FIELD_NUMBER = 3;
            public static final int ROTATION_FIELD_NUMBER = 6;
            public static final int TOP_FIELD_NUMBER = 2;
            public static final int TOP_LEFT_THICKNESS_FIELD_NUMBER = 7;
            private int bitField0_;
            private double bottom_;
            private double left_;
            private boolean normalized_;
            private double right_;
            private double rotation_;
            private double topLeftThickness_;
            private double top_;

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

            private Rectangle() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean hasLeft() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public double getLeft() {
                return this.left_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setLeft(double d) {
                this.bitField0_ |= 1;
                this.left_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearLeft() {
                this.bitField0_ &= -2;
                this.left_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean hasTop() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public double getTop() {
                return this.top_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setTop(double d) {
                this.bitField0_ |= 2;
                this.top_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearTop() {
                this.bitField0_ &= -3;
                this.top_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean hasRight() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public double getRight() {
                return this.right_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRight(double d) {
                this.bitField0_ |= 4;
                this.right_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRight() {
                this.bitField0_ &= -5;
                this.right_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean hasBottom() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public double getBottom() {
                return this.bottom_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setBottom(double d) {
                this.bitField0_ |= 8;
                this.bottom_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearBottom() {
                this.bitField0_ &= -9;
                this.bottom_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean hasNormalized() {
                return (this.bitField0_ & 16) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean getNormalized() {
                return this.normalized_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNormalized(boolean z) {
                this.bitField0_ |= 16;
                this.normalized_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNormalized() {
                this.bitField0_ &= -17;
                this.normalized_ = false;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean hasRotation() {
                return (this.bitField0_ & 32) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public double getRotation() {
                return this.rotation_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRotation(double d) {
                this.bitField0_ |= 32;
                this.rotation_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRotation() {
                this.bitField0_ &= -33;
                this.rotation_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public boolean hasTopLeftThickness() {
                return (this.bitField0_ & 64) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
            public double getTopLeftThickness() {
                return this.topLeftThickness_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setTopLeftThickness(double d) {
                this.bitField0_ |= 64;
                this.topLeftThickness_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearTopLeftThickness() {
                this.bitField0_ &= -65;
                this.topLeftThickness_ = 0.0d;
            }

            public static Rectangle parseFrom(ByteBuffer byteBuffer) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Rectangle parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Rectangle parseFrom(ByteString byteString) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Rectangle parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Rectangle parseFrom(byte[] bArr) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Rectangle parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Rectangle parseFrom(InputStream inputStream) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Rectangle parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Rectangle parseDelimitedFrom(InputStream inputStream) {
                return (Rectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Rectangle parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Rectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Rectangle parseFrom(CodedInputStream codedInputStream) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Rectangle parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Rectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Rectangle rectangle) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(rectangle);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Rectangle, Builder> implements RectangleOrBuilder {
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
                    super(Rectangle.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean hasLeft() {
                    return ((Rectangle) this.instance).hasLeft();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public double getLeft() {
                    return ((Rectangle) this.instance).getLeft();
                }

                public Builder setLeft(double d) {
                    copyOnWrite();
                    ((Rectangle) this.instance).setLeft(d);
                    return this;
                }

                public Builder clearLeft() {
                    copyOnWrite();
                    ((Rectangle) this.instance).clearLeft();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean hasTop() {
                    return ((Rectangle) this.instance).hasTop();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public double getTop() {
                    return ((Rectangle) this.instance).getTop();
                }

                public Builder setTop(double d) {
                    copyOnWrite();
                    ((Rectangle) this.instance).setTop(d);
                    return this;
                }

                public Builder clearTop() {
                    copyOnWrite();
                    ((Rectangle) this.instance).clearTop();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean hasRight() {
                    return ((Rectangle) this.instance).hasRight();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public double getRight() {
                    return ((Rectangle) this.instance).getRight();
                }

                public Builder setRight(double d) {
                    copyOnWrite();
                    ((Rectangle) this.instance).setRight(d);
                    return this;
                }

                public Builder clearRight() {
                    copyOnWrite();
                    ((Rectangle) this.instance).clearRight();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean hasBottom() {
                    return ((Rectangle) this.instance).hasBottom();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public double getBottom() {
                    return ((Rectangle) this.instance).getBottom();
                }

                public Builder setBottom(double d) {
                    copyOnWrite();
                    ((Rectangle) this.instance).setBottom(d);
                    return this;
                }

                public Builder clearBottom() {
                    copyOnWrite();
                    ((Rectangle) this.instance).clearBottom();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean hasNormalized() {
                    return ((Rectangle) this.instance).hasNormalized();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean getNormalized() {
                    return ((Rectangle) this.instance).getNormalized();
                }

                public Builder setNormalized(boolean z) {
                    copyOnWrite();
                    ((Rectangle) this.instance).setNormalized(z);
                    return this;
                }

                public Builder clearNormalized() {
                    copyOnWrite();
                    ((Rectangle) this.instance).clearNormalized();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean hasRotation() {
                    return ((Rectangle) this.instance).hasRotation();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public double getRotation() {
                    return ((Rectangle) this.instance).getRotation();
                }

                public Builder setRotation(double d) {
                    copyOnWrite();
                    ((Rectangle) this.instance).setRotation(d);
                    return this;
                }

                public Builder clearRotation() {
                    copyOnWrite();
                    ((Rectangle) this.instance).clearRotation();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public boolean hasTopLeftThickness() {
                    return ((Rectangle) this.instance).hasTopLeftThickness();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RectangleOrBuilder
                public double getTopLeftThickness() {
                    return ((Rectangle) this.instance).getTopLeftThickness();
                }

                public Builder setTopLeftThickness(double d) {
                    copyOnWrite();
                    ((Rectangle) this.instance).setTopLeftThickness(d);
                    return this;
                }

                public Builder clearTopLeftThickness() {
                    copyOnWrite();
                    ((Rectangle) this.instance).clearTopLeftThickness();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Rectangle();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0007\u0000\u0001\u0001\u0007\u0007\u0000\u0000\u0000\u0001က\u0000\u0002က\u0001\u0003က\u0002\u0004က\u0003\u0005ဇ\u0004\u0006က\u0005\u0007က\u0006", new Object[]{"bitField0_", "left_", "top_", "right_", "bottom_", "normalized_", "rotation_", "topLeftThickness_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Rectangle> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Rectangle.class) {
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
                Rectangle rectangle = new Rectangle();
                DEFAULT_INSTANCE = rectangle;
                GeneratedMessageLite.registerDefaultInstance(Rectangle.class, rectangle);
            }

            public static Rectangle getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Rectangle> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class FilledRectangle extends GeneratedMessageLite<FilledRectangle, Builder> implements FilledRectangleOrBuilder {
            private static final FilledRectangle DEFAULT_INSTANCE;
            public static final int FILL_COLOR_FIELD_NUMBER = 2;
            private static volatile Parser<FilledRectangle> PARSER = null;
            public static final int RECTANGLE_FIELD_NUMBER = 1;
            private int bitField0_;
            private ColorProto.Color fillColor_;
            private Rectangle rectangle_;

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

            private FilledRectangle() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
            public boolean hasRectangle() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
            public Rectangle getRectangle() {
                Rectangle rectangle = this.rectangle_;
                return rectangle == null ? Rectangle.getDefaultInstance() : rectangle;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRectangle(Rectangle rectangle) {
                rectangle.getClass();
                this.rectangle_ = rectangle;
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeRectangle(Rectangle rectangle) {
                rectangle.getClass();
                Rectangle rectangle2 = this.rectangle_;
                if (rectangle2 != null && rectangle2 != Rectangle.getDefaultInstance()) {
                    this.rectangle_ = Rectangle.newBuilder(this.rectangle_).mergeFrom(rectangle).buildPartial();
                } else {
                    this.rectangle_ = rectangle;
                }
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRectangle() {
                this.rectangle_ = null;
                this.bitField0_ &= -2;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
            public boolean hasFillColor() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
            public ColorProto.Color getFillColor() {
                ColorProto.Color color = this.fillColor_;
                return color == null ? ColorProto.Color.getDefaultInstance() : color;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setFillColor(ColorProto.Color color) {
                color.getClass();
                this.fillColor_ = color;
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeFillColor(ColorProto.Color color) {
                color.getClass();
                ColorProto.Color color2 = this.fillColor_;
                if (color2 != null && color2 != ColorProto.Color.getDefaultInstance()) {
                    this.fillColor_ = ColorProto.Color.newBuilder(this.fillColor_).mergeFrom(color).buildPartial();
                } else {
                    this.fillColor_ = color;
                }
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearFillColor() {
                this.fillColor_ = null;
                this.bitField0_ &= -3;
            }

            public static FilledRectangle parseFrom(ByteBuffer byteBuffer) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static FilledRectangle parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static FilledRectangle parseFrom(ByteString byteString) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static FilledRectangle parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static FilledRectangle parseFrom(byte[] bArr) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static FilledRectangle parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static FilledRectangle parseFrom(InputStream inputStream) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static FilledRectangle parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static FilledRectangle parseDelimitedFrom(InputStream inputStream) {
                return (FilledRectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static FilledRectangle parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static FilledRectangle parseFrom(CodedInputStream codedInputStream) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static FilledRectangle parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(FilledRectangle filledRectangle) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(filledRectangle);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<FilledRectangle, Builder> implements FilledRectangleOrBuilder {
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
                    super(FilledRectangle.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
                public boolean hasRectangle() {
                    return ((FilledRectangle) this.instance).hasRectangle();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
                public Rectangle getRectangle() {
                    return ((FilledRectangle) this.instance).getRectangle();
                }

                public Builder setRectangle(Rectangle rectangle) {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).setRectangle(rectangle);
                    return this;
                }

                public Builder setRectangle(Rectangle.Builder builder) {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).setRectangle(builder.build());
                    return this;
                }

                public Builder mergeRectangle(Rectangle rectangle) {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).mergeRectangle(rectangle);
                    return this;
                }

                public Builder clearRectangle() {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).clearRectangle();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
                public boolean hasFillColor() {
                    return ((FilledRectangle) this.instance).hasFillColor();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRectangleOrBuilder
                public ColorProto.Color getFillColor() {
                    return ((FilledRectangle) this.instance).getFillColor();
                }

                public Builder setFillColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).setFillColor(color);
                    return this;
                }

                public Builder setFillColor(ColorProto.Color.Builder builder) {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).setFillColor(builder.build());
                    return this;
                }

                public Builder mergeFillColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).mergeFillColor(color);
                    return this;
                }

                public Builder clearFillColor() {
                    copyOnWrite();
                    ((FilledRectangle) this.instance).clearFillColor();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new FilledRectangle();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001", new Object[]{"bitField0_", "rectangle_", "fillColor_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<FilledRectangle> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (FilledRectangle.class) {
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
                FilledRectangle filledRectangle = new FilledRectangle();
                DEFAULT_INSTANCE = filledRectangle;
                GeneratedMessageLite.registerDefaultInstance(FilledRectangle.class, filledRectangle);
            }

            public static FilledRectangle getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<FilledRectangle> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class RoundedRectangle extends GeneratedMessageLite<RoundedRectangle, Builder> implements RoundedRectangleOrBuilder {
            public static final int CORNER_RADIUS_FIELD_NUMBER = 2;
            private static final RoundedRectangle DEFAULT_INSTANCE;
            public static final int LINE_TYPE_FIELD_NUMBER = 3;
            private static volatile Parser<RoundedRectangle> PARSER = null;
            public static final int RECTANGLE_FIELD_NUMBER = 1;
            private int bitField0_;
            private int cornerRadius_;
            private int lineType_ = 4;
            private Rectangle rectangle_;

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

            private RoundedRectangle() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
            public boolean hasRectangle() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
            public Rectangle getRectangle() {
                Rectangle rectangle = this.rectangle_;
                return rectangle == null ? Rectangle.getDefaultInstance() : rectangle;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRectangle(Rectangle rectangle) {
                rectangle.getClass();
                this.rectangle_ = rectangle;
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeRectangle(Rectangle rectangle) {
                rectangle.getClass();
                Rectangle rectangle2 = this.rectangle_;
                if (rectangle2 != null && rectangle2 != Rectangle.getDefaultInstance()) {
                    this.rectangle_ = Rectangle.newBuilder(this.rectangle_).mergeFrom(rectangle).buildPartial();
                } else {
                    this.rectangle_ = rectangle;
                }
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRectangle() {
                this.rectangle_ = null;
                this.bitField0_ &= -2;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
            public boolean hasCornerRadius() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
            public int getCornerRadius() {
                return this.cornerRadius_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setCornerRadius(int i) {
                this.bitField0_ |= 2;
                this.cornerRadius_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearCornerRadius() {
                this.bitField0_ &= -3;
                this.cornerRadius_ = 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
            public boolean hasLineType() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
            public int getLineType() {
                return this.lineType_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setLineType(int i) {
                this.bitField0_ |= 4;
                this.lineType_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearLineType() {
                this.bitField0_ &= -5;
                this.lineType_ = 4;
            }

            public static RoundedRectangle parseFrom(ByteBuffer byteBuffer) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static RoundedRectangle parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static RoundedRectangle parseFrom(ByteString byteString) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static RoundedRectangle parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static RoundedRectangle parseFrom(byte[] bArr) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static RoundedRectangle parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static RoundedRectangle parseFrom(InputStream inputStream) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static RoundedRectangle parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static RoundedRectangle parseDelimitedFrom(InputStream inputStream) {
                return (RoundedRectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static RoundedRectangle parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RoundedRectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static RoundedRectangle parseFrom(CodedInputStream codedInputStream) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static RoundedRectangle parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (RoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(RoundedRectangle roundedRectangle) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(roundedRectangle);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<RoundedRectangle, Builder> implements RoundedRectangleOrBuilder {
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
                    super(RoundedRectangle.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
                public boolean hasRectangle() {
                    return ((RoundedRectangle) this.instance).hasRectangle();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
                public Rectangle getRectangle() {
                    return ((RoundedRectangle) this.instance).getRectangle();
                }

                public Builder setRectangle(Rectangle rectangle) {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).setRectangle(rectangle);
                    return this;
                }

                public Builder setRectangle(Rectangle.Builder builder) {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).setRectangle(builder.build());
                    return this;
                }

                public Builder mergeRectangle(Rectangle rectangle) {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).mergeRectangle(rectangle);
                    return this;
                }

                public Builder clearRectangle() {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).clearRectangle();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
                public boolean hasCornerRadius() {
                    return ((RoundedRectangle) this.instance).hasCornerRadius();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
                public int getCornerRadius() {
                    return ((RoundedRectangle) this.instance).getCornerRadius();
                }

                public Builder setCornerRadius(int i) {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).setCornerRadius(i);
                    return this;
                }

                public Builder clearCornerRadius() {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).clearCornerRadius();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
                public boolean hasLineType() {
                    return ((RoundedRectangle) this.instance).hasLineType();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.RoundedRectangleOrBuilder
                public int getLineType() {
                    return ((RoundedRectangle) this.instance).getLineType();
                }

                public Builder setLineType(int i) {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).setLineType(i);
                    return this;
                }

                public Builder clearLineType() {
                    copyOnWrite();
                    ((RoundedRectangle) this.instance).clearLineType();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new RoundedRectangle();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001ဉ\u0000\u0002င\u0001\u0003င\u0002", new Object[]{"bitField0_", "rectangle_", "cornerRadius_", "lineType_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<RoundedRectangle> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (RoundedRectangle.class) {
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
                RoundedRectangle roundedRectangle = new RoundedRectangle();
                DEFAULT_INSTANCE = roundedRectangle;
                GeneratedMessageLite.registerDefaultInstance(RoundedRectangle.class, roundedRectangle);
            }

            public static RoundedRectangle getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<RoundedRectangle> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class FilledRoundedRectangle extends GeneratedMessageLite<FilledRoundedRectangle, Builder> implements FilledRoundedRectangleOrBuilder {
            private static final FilledRoundedRectangle DEFAULT_INSTANCE;
            public static final int FILL_COLOR_FIELD_NUMBER = 2;
            private static volatile Parser<FilledRoundedRectangle> PARSER = null;
            public static final int ROUNDED_RECTANGLE_FIELD_NUMBER = 1;
            private int bitField0_;
            private ColorProto.Color fillColor_;
            private RoundedRectangle roundedRectangle_;

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

            private FilledRoundedRectangle() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
            public boolean hasRoundedRectangle() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
            public RoundedRectangle getRoundedRectangle() {
                RoundedRectangle roundedRectangle = this.roundedRectangle_;
                return roundedRectangle == null ? RoundedRectangle.getDefaultInstance() : roundedRectangle;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRoundedRectangle(RoundedRectangle roundedRectangle) {
                roundedRectangle.getClass();
                this.roundedRectangle_ = roundedRectangle;
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeRoundedRectangle(RoundedRectangle roundedRectangle) {
                roundedRectangle.getClass();
                RoundedRectangle roundedRectangle2 = this.roundedRectangle_;
                if (roundedRectangle2 != null && roundedRectangle2 != RoundedRectangle.getDefaultInstance()) {
                    this.roundedRectangle_ = RoundedRectangle.newBuilder(this.roundedRectangle_).mergeFrom(roundedRectangle).buildPartial();
                } else {
                    this.roundedRectangle_ = roundedRectangle;
                }
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRoundedRectangle() {
                this.roundedRectangle_ = null;
                this.bitField0_ &= -2;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
            public boolean hasFillColor() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
            public ColorProto.Color getFillColor() {
                ColorProto.Color color = this.fillColor_;
                return color == null ? ColorProto.Color.getDefaultInstance() : color;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setFillColor(ColorProto.Color color) {
                color.getClass();
                this.fillColor_ = color;
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeFillColor(ColorProto.Color color) {
                color.getClass();
                ColorProto.Color color2 = this.fillColor_;
                if (color2 != null && color2 != ColorProto.Color.getDefaultInstance()) {
                    this.fillColor_ = ColorProto.Color.newBuilder(this.fillColor_).mergeFrom(color).buildPartial();
                } else {
                    this.fillColor_ = color;
                }
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearFillColor() {
                this.fillColor_ = null;
                this.bitField0_ &= -3;
            }

            public static FilledRoundedRectangle parseFrom(ByteBuffer byteBuffer) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static FilledRoundedRectangle parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static FilledRoundedRectangle parseFrom(ByteString byteString) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static FilledRoundedRectangle parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static FilledRoundedRectangle parseFrom(byte[] bArr) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static FilledRoundedRectangle parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static FilledRoundedRectangle parseFrom(InputStream inputStream) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static FilledRoundedRectangle parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static FilledRoundedRectangle parseDelimitedFrom(InputStream inputStream) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static FilledRoundedRectangle parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static FilledRoundedRectangle parseFrom(CodedInputStream codedInputStream) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static FilledRoundedRectangle parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledRoundedRectangle) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(FilledRoundedRectangle filledRoundedRectangle) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(filledRoundedRectangle);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<FilledRoundedRectangle, Builder> implements FilledRoundedRectangleOrBuilder {
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
                    super(FilledRoundedRectangle.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
                public boolean hasRoundedRectangle() {
                    return ((FilledRoundedRectangle) this.instance).hasRoundedRectangle();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
                public RoundedRectangle getRoundedRectangle() {
                    return ((FilledRoundedRectangle) this.instance).getRoundedRectangle();
                }

                public Builder setRoundedRectangle(RoundedRectangle roundedRectangle) {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).setRoundedRectangle(roundedRectangle);
                    return this;
                }

                public Builder setRoundedRectangle(RoundedRectangle.Builder builder) {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).setRoundedRectangle(builder.build());
                    return this;
                }

                public Builder mergeRoundedRectangle(RoundedRectangle roundedRectangle) {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).mergeRoundedRectangle(roundedRectangle);
                    return this;
                }

                public Builder clearRoundedRectangle() {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).clearRoundedRectangle();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
                public boolean hasFillColor() {
                    return ((FilledRoundedRectangle) this.instance).hasFillColor();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledRoundedRectangleOrBuilder
                public ColorProto.Color getFillColor() {
                    return ((FilledRoundedRectangle) this.instance).getFillColor();
                }

                public Builder setFillColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).setFillColor(color);
                    return this;
                }

                public Builder setFillColor(ColorProto.Color.Builder builder) {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).setFillColor(builder.build());
                    return this;
                }

                public Builder mergeFillColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).mergeFillColor(color);
                    return this;
                }

                public Builder clearFillColor() {
                    copyOnWrite();
                    ((FilledRoundedRectangle) this.instance).clearFillColor();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new FilledRoundedRectangle();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001", new Object[]{"bitField0_", "roundedRectangle_", "fillColor_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<FilledRoundedRectangle> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (FilledRoundedRectangle.class) {
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
                FilledRoundedRectangle filledRoundedRectangle = new FilledRoundedRectangle();
                DEFAULT_INSTANCE = filledRoundedRectangle;
                GeneratedMessageLite.registerDefaultInstance(FilledRoundedRectangle.class, filledRoundedRectangle);
            }

            public static FilledRoundedRectangle getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<FilledRoundedRectangle> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class Oval extends GeneratedMessageLite<Oval, Builder> implements OvalOrBuilder {
            private static final Oval DEFAULT_INSTANCE;
            private static volatile Parser<Oval> PARSER = null;
            public static final int RECTANGLE_FIELD_NUMBER = 1;
            private int bitField0_;
            private Rectangle rectangle_;

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

            private Oval() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.OvalOrBuilder
            public boolean hasRectangle() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.OvalOrBuilder
            public Rectangle getRectangle() {
                Rectangle rectangle = this.rectangle_;
                return rectangle == null ? Rectangle.getDefaultInstance() : rectangle;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setRectangle(Rectangle rectangle) {
                rectangle.getClass();
                this.rectangle_ = rectangle;
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeRectangle(Rectangle rectangle) {
                rectangle.getClass();
                Rectangle rectangle2 = this.rectangle_;
                if (rectangle2 != null && rectangle2 != Rectangle.getDefaultInstance()) {
                    this.rectangle_ = Rectangle.newBuilder(this.rectangle_).mergeFrom(rectangle).buildPartial();
                } else {
                    this.rectangle_ = rectangle;
                }
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearRectangle() {
                this.rectangle_ = null;
                this.bitField0_ &= -2;
            }

            public static Oval parseFrom(ByteBuffer byteBuffer) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Oval parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Oval parseFrom(ByteString byteString) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Oval parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Oval parseFrom(byte[] bArr) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Oval parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Oval parseFrom(InputStream inputStream) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Oval parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Oval parseDelimitedFrom(InputStream inputStream) {
                return (Oval) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Oval parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Oval) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Oval parseFrom(CodedInputStream codedInputStream) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Oval parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Oval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Oval oval) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(oval);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Oval, Builder> implements OvalOrBuilder {
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
                    super(Oval.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.OvalOrBuilder
                public boolean hasRectangle() {
                    return ((Oval) this.instance).hasRectangle();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.OvalOrBuilder
                public Rectangle getRectangle() {
                    return ((Oval) this.instance).getRectangle();
                }

                public Builder setRectangle(Rectangle rectangle) {
                    copyOnWrite();
                    ((Oval) this.instance).setRectangle(rectangle);
                    return this;
                }

                public Builder setRectangle(Rectangle.Builder builder) {
                    copyOnWrite();
                    ((Oval) this.instance).setRectangle(builder.build());
                    return this;
                }

                public Builder mergeRectangle(Rectangle rectangle) {
                    copyOnWrite();
                    ((Oval) this.instance).mergeRectangle(rectangle);
                    return this;
                }

                public Builder clearRectangle() {
                    copyOnWrite();
                    ((Oval) this.instance).clearRectangle();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Oval();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0001\u0001\u0001\u0001\u0000\u0000\u0000\u0001ဉ\u0000", new Object[]{"bitField0_", "rectangle_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Oval> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Oval.class) {
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
                Oval oval = new Oval();
                DEFAULT_INSTANCE = oval;
                GeneratedMessageLite.registerDefaultInstance(Oval.class, oval);
            }

            public static Oval getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Oval> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class FilledOval extends GeneratedMessageLite<FilledOval, Builder> implements FilledOvalOrBuilder {
            private static final FilledOval DEFAULT_INSTANCE;
            public static final int FILL_COLOR_FIELD_NUMBER = 2;
            public static final int OVAL_FIELD_NUMBER = 1;
            private static volatile Parser<FilledOval> PARSER;
            private int bitField0_;
            private ColorProto.Color fillColor_;
            private Oval oval_;

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

            private FilledOval() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
            public boolean hasOval() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
            public Oval getOval() {
                Oval oval = this.oval_;
                return oval == null ? Oval.getDefaultInstance() : oval;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOval(Oval oval) {
                oval.getClass();
                this.oval_ = oval;
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeOval(Oval oval) {
                oval.getClass();
                Oval oval2 = this.oval_;
                if (oval2 != null && oval2 != Oval.getDefaultInstance()) {
                    this.oval_ = Oval.newBuilder(this.oval_).mergeFrom(oval).buildPartial();
                } else {
                    this.oval_ = oval;
                }
                this.bitField0_ |= 1;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOval() {
                this.oval_ = null;
                this.bitField0_ &= -2;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
            public boolean hasFillColor() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
            public ColorProto.Color getFillColor() {
                ColorProto.Color color = this.fillColor_;
                return color == null ? ColorProto.Color.getDefaultInstance() : color;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setFillColor(ColorProto.Color color) {
                color.getClass();
                this.fillColor_ = color;
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeFillColor(ColorProto.Color color) {
                color.getClass();
                ColorProto.Color color2 = this.fillColor_;
                if (color2 != null && color2 != ColorProto.Color.getDefaultInstance()) {
                    this.fillColor_ = ColorProto.Color.newBuilder(this.fillColor_).mergeFrom(color).buildPartial();
                } else {
                    this.fillColor_ = color;
                }
                this.bitField0_ |= 2;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearFillColor() {
                this.fillColor_ = null;
                this.bitField0_ &= -3;
            }

            public static FilledOval parseFrom(ByteBuffer byteBuffer) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static FilledOval parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static FilledOval parseFrom(ByteString byteString) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static FilledOval parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static FilledOval parseFrom(byte[] bArr) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static FilledOval parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static FilledOval parseFrom(InputStream inputStream) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static FilledOval parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static FilledOval parseDelimitedFrom(InputStream inputStream) {
                return (FilledOval) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static FilledOval parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledOval) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static FilledOval parseFrom(CodedInputStream codedInputStream) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static FilledOval parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (FilledOval) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(FilledOval filledOval) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(filledOval);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<FilledOval, Builder> implements FilledOvalOrBuilder {
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
                    super(FilledOval.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
                public boolean hasOval() {
                    return ((FilledOval) this.instance).hasOval();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
                public Oval getOval() {
                    return ((FilledOval) this.instance).getOval();
                }

                public Builder setOval(Oval oval) {
                    copyOnWrite();
                    ((FilledOval) this.instance).setOval(oval);
                    return this;
                }

                public Builder setOval(Oval.Builder builder) {
                    copyOnWrite();
                    ((FilledOval) this.instance).setOval(builder.build());
                    return this;
                }

                public Builder mergeOval(Oval oval) {
                    copyOnWrite();
                    ((FilledOval) this.instance).mergeOval(oval);
                    return this;
                }

                public Builder clearOval() {
                    copyOnWrite();
                    ((FilledOval) this.instance).clearOval();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
                public boolean hasFillColor() {
                    return ((FilledOval) this.instance).hasFillColor();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.FilledOvalOrBuilder
                public ColorProto.Color getFillColor() {
                    return ((FilledOval) this.instance).getFillColor();
                }

                public Builder setFillColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((FilledOval) this.instance).setFillColor(color);
                    return this;
                }

                public Builder setFillColor(ColorProto.Color.Builder builder) {
                    copyOnWrite();
                    ((FilledOval) this.instance).setFillColor(builder.build());
                    return this;
                }

                public Builder mergeFillColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((FilledOval) this.instance).mergeFillColor(color);
                    return this;
                }

                public Builder clearFillColor() {
                    copyOnWrite();
                    ((FilledOval) this.instance).clearFillColor();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new FilledOval();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0002\u0000\u0001\u0001\u0002\u0002\u0000\u0000\u0000\u0001ဉ\u0000\u0002ဉ\u0001", new Object[]{"bitField0_", "oval_", "fillColor_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<FilledOval> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (FilledOval.class) {
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
                FilledOval filledOval = new FilledOval();
                DEFAULT_INSTANCE = filledOval;
                GeneratedMessageLite.registerDefaultInstance(FilledOval.class, filledOval);
            }

            public static FilledOval getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<FilledOval> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class Point extends GeneratedMessageLite<Point, Builder> implements PointOrBuilder {
            private static final Point DEFAULT_INSTANCE;
            public static final int NORMALIZED_FIELD_NUMBER = 3;
            private static volatile Parser<Point> PARSER = null;
            public static final int X_FIELD_NUMBER = 1;
            public static final int Y_FIELD_NUMBER = 2;
            private int bitField0_;
            private boolean normalized_;
            private double x_;
            private double y_;

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

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
            public boolean hasX() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
            public double getX() {
                return this.x_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setX(double d) {
                this.bitField0_ |= 1;
                this.x_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearX() {
                this.bitField0_ &= -2;
                this.x_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
            public boolean hasY() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
            public double getY() {
                return this.y_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setY(double d) {
                this.bitField0_ |= 2;
                this.y_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearY() {
                this.bitField0_ &= -3;
                this.y_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
            public boolean hasNormalized() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
            public boolean getNormalized() {
                return this.normalized_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNormalized(boolean z) {
                this.bitField0_ |= 4;
                this.normalized_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNormalized() {
                this.bitField0_ &= -5;
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

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
                public boolean hasX() {
                    return ((Point) this.instance).hasX();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
                public double getX() {
                    return ((Point) this.instance).getX();
                }

                public Builder setX(double d) {
                    copyOnWrite();
                    ((Point) this.instance).setX(d);
                    return this;
                }

                public Builder clearX() {
                    copyOnWrite();
                    ((Point) this.instance).clearX();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
                public boolean hasY() {
                    return ((Point) this.instance).hasY();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
                public double getY() {
                    return ((Point) this.instance).getY();
                }

                public Builder setY(double d) {
                    copyOnWrite();
                    ((Point) this.instance).setY(d);
                    return this;
                }

                public Builder clearY() {
                    copyOnWrite();
                    ((Point) this.instance).clearY();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
                public boolean hasNormalized() {
                    return ((Point) this.instance).hasNormalized();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.PointOrBuilder
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
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0003\u0000\u0001\u0001\u0003\u0003\u0000\u0000\u0000\u0001က\u0000\u0002က\u0001\u0003ဇ\u0002", new Object[]{"bitField0_", "x_", "y_", "normalized_"});
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

        public static final class Line extends GeneratedMessageLite<Line, Builder> implements LineOrBuilder {
            private static final Line DEFAULT_INSTANCE;
            public static final int LINE_TYPE_FIELD_NUMBER = 6;
            public static final int NORMALIZED_FIELD_NUMBER = 5;
            private static volatile Parser<Line> PARSER = null;
            public static final int X_END_FIELD_NUMBER = 3;
            public static final int X_START_FIELD_NUMBER = 1;
            public static final int Y_END_FIELD_NUMBER = 4;
            public static final int Y_START_FIELD_NUMBER = 2;
            private int bitField0_;
            private int lineType_ = 1;
            private boolean normalized_;
            private double xEnd_;
            private double xStart_;
            private double yEnd_;
            private double yStart_;

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

            private Line() {
            }

            public enum LineType implements Internal.EnumLite {
                UNKNOWN(0),
                SOLID(1),
                DASHED(2);

                public static final int DASHED_VALUE = 2;
                public static final int SOLID_VALUE = 1;
                public static final int UNKNOWN_VALUE = 0;
                private static final Internal.EnumLiteMap<LineType> internalValueMap = new Internal.EnumLiteMap<LineType>() { // from class: com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.Line.LineType.1
                    @Override // com.google.protobuf.Internal.EnumLiteMap
                    public LineType findValueByNumber(int i) {
                        return LineType.forNumber(i);
                    }
                };
                private final int value;

                @Override // com.google.protobuf.Internal.EnumLite
                public final int getNumber() {
                    return this.value;
                }

                @Deprecated
                public static LineType valueOf(int i) {
                    return forNumber(i);
                }

                public static LineType forNumber(int i) {
                    if (i == 0) {
                        return UNKNOWN;
                    }
                    if (i == 1) {
                        return SOLID;
                    }
                    if (i != 2) {
                        return null;
                    }
                    return DASHED;
                }

                public static Internal.EnumLiteMap<LineType> internalGetValueMap() {
                    return internalValueMap;
                }

                public static Internal.EnumVerifier internalGetVerifier() {
                    return LineTypeVerifier.INSTANCE;
                }

                private static final class LineTypeVerifier implements Internal.EnumVerifier {
                    static final Internal.EnumVerifier INSTANCE = new LineTypeVerifier();

                    private LineTypeVerifier() {
                    }

                    @Override // com.google.protobuf.Internal.EnumVerifier
                    public boolean isInRange(int i) {
                        return LineType.forNumber(i) != null;
                    }
                }

                LineType(int i) {
                    this.value = i;
                }
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public boolean hasXStart() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public double getXStart() {
                return this.xStart_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXStart(double d) {
                this.bitField0_ |= 1;
                this.xStart_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXStart() {
                this.bitField0_ &= -2;
                this.xStart_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public boolean hasYStart() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public double getYStart() {
                return this.yStart_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYStart(double d) {
                this.bitField0_ |= 2;
                this.yStart_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYStart() {
                this.bitField0_ &= -3;
                this.yStart_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public boolean hasXEnd() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public double getXEnd() {
                return this.xEnd_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXEnd(double d) {
                this.bitField0_ |= 4;
                this.xEnd_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXEnd() {
                this.bitField0_ &= -5;
                this.xEnd_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public boolean hasYEnd() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public double getYEnd() {
                return this.yEnd_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYEnd(double d) {
                this.bitField0_ |= 8;
                this.yEnd_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYEnd() {
                this.bitField0_ &= -9;
                this.yEnd_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public boolean hasNormalized() {
                return (this.bitField0_ & 16) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public boolean getNormalized() {
                return this.normalized_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNormalized(boolean z) {
                this.bitField0_ |= 16;
                this.normalized_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNormalized() {
                this.bitField0_ &= -17;
                this.normalized_ = false;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public boolean hasLineType() {
                return (this.bitField0_ & 32) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
            public LineType getLineType() {
                LineType lineTypeForNumber = LineType.forNumber(this.lineType_);
                return lineTypeForNumber == null ? LineType.SOLID : lineTypeForNumber;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setLineType(LineType lineType) {
                this.lineType_ = lineType.getNumber();
                this.bitField0_ |= 32;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearLineType() {
                this.bitField0_ &= -33;
                this.lineType_ = 1;
            }

            public static Line parseFrom(ByteBuffer byteBuffer) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Line parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Line parseFrom(ByteString byteString) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Line parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Line parseFrom(byte[] bArr) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Line parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Line parseFrom(InputStream inputStream) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Line parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Line parseDelimitedFrom(InputStream inputStream) {
                return (Line) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Line parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Line) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Line parseFrom(CodedInputStream codedInputStream) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Line parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Line) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Line line) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(line);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Line, Builder> implements LineOrBuilder {
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
                    super(Line.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public boolean hasXStart() {
                    return ((Line) this.instance).hasXStart();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public double getXStart() {
                    return ((Line) this.instance).getXStart();
                }

                public Builder setXStart(double d) {
                    copyOnWrite();
                    ((Line) this.instance).setXStart(d);
                    return this;
                }

                public Builder clearXStart() {
                    copyOnWrite();
                    ((Line) this.instance).clearXStart();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public boolean hasYStart() {
                    return ((Line) this.instance).hasYStart();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public double getYStart() {
                    return ((Line) this.instance).getYStart();
                }

                public Builder setYStart(double d) {
                    copyOnWrite();
                    ((Line) this.instance).setYStart(d);
                    return this;
                }

                public Builder clearYStart() {
                    copyOnWrite();
                    ((Line) this.instance).clearYStart();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public boolean hasXEnd() {
                    return ((Line) this.instance).hasXEnd();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public double getXEnd() {
                    return ((Line) this.instance).getXEnd();
                }

                public Builder setXEnd(double d) {
                    copyOnWrite();
                    ((Line) this.instance).setXEnd(d);
                    return this;
                }

                public Builder clearXEnd() {
                    copyOnWrite();
                    ((Line) this.instance).clearXEnd();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public boolean hasYEnd() {
                    return ((Line) this.instance).hasYEnd();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public double getYEnd() {
                    return ((Line) this.instance).getYEnd();
                }

                public Builder setYEnd(double d) {
                    copyOnWrite();
                    ((Line) this.instance).setYEnd(d);
                    return this;
                }

                public Builder clearYEnd() {
                    copyOnWrite();
                    ((Line) this.instance).clearYEnd();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public boolean hasNormalized() {
                    return ((Line) this.instance).hasNormalized();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public boolean getNormalized() {
                    return ((Line) this.instance).getNormalized();
                }

                public Builder setNormalized(boolean z) {
                    copyOnWrite();
                    ((Line) this.instance).setNormalized(z);
                    return this;
                }

                public Builder clearNormalized() {
                    copyOnWrite();
                    ((Line) this.instance).clearNormalized();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public boolean hasLineType() {
                    return ((Line) this.instance).hasLineType();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.LineOrBuilder
                public LineType getLineType() {
                    return ((Line) this.instance).getLineType();
                }

                public Builder setLineType(LineType lineType) {
                    copyOnWrite();
                    ((Line) this.instance).setLineType(lineType);
                    return this;
                }

                public Builder clearLineType() {
                    copyOnWrite();
                    ((Line) this.instance).clearLineType();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Line();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0006\u0000\u0001\u0001\u0006\u0006\u0000\u0000\u0000\u0001က\u0000\u0002က\u0001\u0003က\u0002\u0004က\u0003\u0005ဇ\u0004\u0006᠌\u0005", new Object[]{"bitField0_", "xStart_", "yStart_", "xEnd_", "yEnd_", "normalized_", "lineType_", LineType.internalGetVerifier()});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Line> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Line.class) {
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
                Line line = new Line();
                DEFAULT_INSTANCE = line;
                GeneratedMessageLite.registerDefaultInstance(Line.class, line);
            }

            public static Line getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Line> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class GradientLine extends GeneratedMessageLite<GradientLine, Builder> implements GradientLineOrBuilder {
            public static final int COLOR1_FIELD_NUMBER = 6;
            public static final int COLOR2_FIELD_NUMBER = 7;
            private static final GradientLine DEFAULT_INSTANCE;
            public static final int NORMALIZED_FIELD_NUMBER = 5;
            private static volatile Parser<GradientLine> PARSER = null;
            public static final int X_END_FIELD_NUMBER = 3;
            public static final int X_START_FIELD_NUMBER = 1;
            public static final int Y_END_FIELD_NUMBER = 4;
            public static final int Y_START_FIELD_NUMBER = 2;
            private int bitField0_;
            private ColorProto.Color color1_;
            private ColorProto.Color color2_;
            private boolean normalized_;
            private double xEnd_;
            private double xStart_;
            private double yEnd_;
            private double yStart_;

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

            private GradientLine() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean hasXStart() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public double getXStart() {
                return this.xStart_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXStart(double d) {
                this.bitField0_ |= 1;
                this.xStart_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXStart() {
                this.bitField0_ &= -2;
                this.xStart_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean hasYStart() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public double getYStart() {
                return this.yStart_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYStart(double d) {
                this.bitField0_ |= 2;
                this.yStart_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYStart() {
                this.bitField0_ &= -3;
                this.yStart_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean hasXEnd() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public double getXEnd() {
                return this.xEnd_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXEnd(double d) {
                this.bitField0_ |= 4;
                this.xEnd_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXEnd() {
                this.bitField0_ &= -5;
                this.xEnd_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean hasYEnd() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public double getYEnd() {
                return this.yEnd_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYEnd(double d) {
                this.bitField0_ |= 8;
                this.yEnd_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYEnd() {
                this.bitField0_ &= -9;
                this.yEnd_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean hasNormalized() {
                return (this.bitField0_ & 16) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean getNormalized() {
                return this.normalized_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNormalized(boolean z) {
                this.bitField0_ |= 16;
                this.normalized_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNormalized() {
                this.bitField0_ &= -17;
                this.normalized_ = false;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean hasColor1() {
                return (this.bitField0_ & 32) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public ColorProto.Color getColor1() {
                ColorProto.Color color = this.color1_;
                return color == null ? ColorProto.Color.getDefaultInstance() : color;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setColor1(ColorProto.Color color) {
                color.getClass();
                this.color1_ = color;
                this.bitField0_ |= 32;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeColor1(ColorProto.Color color) {
                color.getClass();
                ColorProto.Color color2 = this.color1_;
                if (color2 != null && color2 != ColorProto.Color.getDefaultInstance()) {
                    this.color1_ = ColorProto.Color.newBuilder(this.color1_).mergeFrom(color).buildPartial();
                } else {
                    this.color1_ = color;
                }
                this.bitField0_ |= 32;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearColor1() {
                this.color1_ = null;
                this.bitField0_ &= -33;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public boolean hasColor2() {
                return (this.bitField0_ & 64) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
            public ColorProto.Color getColor2() {
                ColorProto.Color color = this.color2_;
                return color == null ? ColorProto.Color.getDefaultInstance() : color;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setColor2(ColorProto.Color color) {
                color.getClass();
                this.color2_ = color;
                this.bitField0_ |= 64;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeColor2(ColorProto.Color color) {
                color.getClass();
                ColorProto.Color color2 = this.color2_;
                if (color2 != null && color2 != ColorProto.Color.getDefaultInstance()) {
                    this.color2_ = ColorProto.Color.newBuilder(this.color2_).mergeFrom(color).buildPartial();
                } else {
                    this.color2_ = color;
                }
                this.bitField0_ |= 64;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearColor2() {
                this.color2_ = null;
                this.bitField0_ &= -65;
            }

            public static GradientLine parseFrom(ByteBuffer byteBuffer) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static GradientLine parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static GradientLine parseFrom(ByteString byteString) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static GradientLine parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static GradientLine parseFrom(byte[] bArr) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static GradientLine parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static GradientLine parseFrom(InputStream inputStream) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static GradientLine parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static GradientLine parseDelimitedFrom(InputStream inputStream) {
                return (GradientLine) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static GradientLine parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (GradientLine) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static GradientLine parseFrom(CodedInputStream codedInputStream) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static GradientLine parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (GradientLine) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(GradientLine gradientLine) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(gradientLine);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<GradientLine, Builder> implements GradientLineOrBuilder {
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
                    super(GradientLine.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean hasXStart() {
                    return ((GradientLine) this.instance).hasXStart();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public double getXStart() {
                    return ((GradientLine) this.instance).getXStart();
                }

                public Builder setXStart(double d) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setXStart(d);
                    return this;
                }

                public Builder clearXStart() {
                    copyOnWrite();
                    ((GradientLine) this.instance).clearXStart();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean hasYStart() {
                    return ((GradientLine) this.instance).hasYStart();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public double getYStart() {
                    return ((GradientLine) this.instance).getYStart();
                }

                public Builder setYStart(double d) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setYStart(d);
                    return this;
                }

                public Builder clearYStart() {
                    copyOnWrite();
                    ((GradientLine) this.instance).clearYStart();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean hasXEnd() {
                    return ((GradientLine) this.instance).hasXEnd();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public double getXEnd() {
                    return ((GradientLine) this.instance).getXEnd();
                }

                public Builder setXEnd(double d) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setXEnd(d);
                    return this;
                }

                public Builder clearXEnd() {
                    copyOnWrite();
                    ((GradientLine) this.instance).clearXEnd();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean hasYEnd() {
                    return ((GradientLine) this.instance).hasYEnd();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public double getYEnd() {
                    return ((GradientLine) this.instance).getYEnd();
                }

                public Builder setYEnd(double d) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setYEnd(d);
                    return this;
                }

                public Builder clearYEnd() {
                    copyOnWrite();
                    ((GradientLine) this.instance).clearYEnd();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean hasNormalized() {
                    return ((GradientLine) this.instance).hasNormalized();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean getNormalized() {
                    return ((GradientLine) this.instance).getNormalized();
                }

                public Builder setNormalized(boolean z) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setNormalized(z);
                    return this;
                }

                public Builder clearNormalized() {
                    copyOnWrite();
                    ((GradientLine) this.instance).clearNormalized();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean hasColor1() {
                    return ((GradientLine) this.instance).hasColor1();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public ColorProto.Color getColor1() {
                    return ((GradientLine) this.instance).getColor1();
                }

                public Builder setColor1(ColorProto.Color color) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setColor1(color);
                    return this;
                }

                public Builder setColor1(ColorProto.Color.Builder builder) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setColor1(builder.build());
                    return this;
                }

                public Builder mergeColor1(ColorProto.Color color) {
                    copyOnWrite();
                    ((GradientLine) this.instance).mergeColor1(color);
                    return this;
                }

                public Builder clearColor1() {
                    copyOnWrite();
                    ((GradientLine) this.instance).clearColor1();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public boolean hasColor2() {
                    return ((GradientLine) this.instance).hasColor2();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.GradientLineOrBuilder
                public ColorProto.Color getColor2() {
                    return ((GradientLine) this.instance).getColor2();
                }

                public Builder setColor2(ColorProto.Color color) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setColor2(color);
                    return this;
                }

                public Builder setColor2(ColorProto.Color.Builder builder) {
                    copyOnWrite();
                    ((GradientLine) this.instance).setColor2(builder.build());
                    return this;
                }

                public Builder mergeColor2(ColorProto.Color color) {
                    copyOnWrite();
                    ((GradientLine) this.instance).mergeColor2(color);
                    return this;
                }

                public Builder clearColor2() {
                    copyOnWrite();
                    ((GradientLine) this.instance).clearColor2();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new GradientLine();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0007\u0000\u0001\u0001\u0007\u0007\u0000\u0000\u0000\u0001က\u0000\u0002က\u0001\u0003က\u0002\u0004က\u0003\u0005ဇ\u0004\u0006ဉ\u0005\u0007ဉ\u0006", new Object[]{"bitField0_", "xStart_", "yStart_", "xEnd_", "yEnd_", "normalized_", "color1_", "color2_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<GradientLine> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (GradientLine.class) {
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
                GradientLine gradientLine = new GradientLine();
                DEFAULT_INSTANCE = gradientLine;
                GeneratedMessageLite.registerDefaultInstance(GradientLine.class, gradientLine);
            }

            public static GradientLine getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<GradientLine> parser() {
                return DEFAULT_INSTANCE.getParserForType();
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

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ScribbleOrBuilder
            public List<Point> getPointList() {
                return this.point_;
            }

            public List<? extends PointOrBuilder> getPointOrBuilderList() {
                return this.point_;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ScribbleOrBuilder
            public int getPointCount() {
                return this.point_.size();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ScribbleOrBuilder
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

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ScribbleOrBuilder
                public List<Point> getPointList() {
                    return Collections.unmodifiableList(((Scribble) this.instance).getPointList());
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ScribbleOrBuilder
                public int getPointCount() {
                    return ((Scribble) this.instance).getPointCount();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ScribbleOrBuilder
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
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0001\u0000\u0000\u0001\u0001\u0001\u0000\u0001\u0000\u0001\u001b", new Object[]{"point_", Point.class});
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

        public static final class Arrow extends GeneratedMessageLite<Arrow, Builder> implements ArrowOrBuilder {
            private static final Arrow DEFAULT_INSTANCE;
            public static final int NORMALIZED_FIELD_NUMBER = 5;
            private static volatile Parser<Arrow> PARSER = null;
            public static final int X_END_FIELD_NUMBER = 3;
            public static final int X_START_FIELD_NUMBER = 1;
            public static final int Y_END_FIELD_NUMBER = 4;
            public static final int Y_START_FIELD_NUMBER = 2;
            private int bitField0_;
            private boolean normalized_;
            private double xEnd_;
            private double xStart_;
            private double yEnd_;
            private double yStart_;

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

            private Arrow() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public boolean hasXStart() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public double getXStart() {
                return this.xStart_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXStart(double d) {
                this.bitField0_ |= 1;
                this.xStart_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXStart() {
                this.bitField0_ &= -2;
                this.xStart_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public boolean hasYStart() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public double getYStart() {
                return this.yStart_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYStart(double d) {
                this.bitField0_ |= 2;
                this.yStart_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYStart() {
                this.bitField0_ &= -3;
                this.yStart_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public boolean hasXEnd() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public double getXEnd() {
                return this.xEnd_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setXEnd(double d) {
                this.bitField0_ |= 4;
                this.xEnd_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearXEnd() {
                this.bitField0_ &= -5;
                this.xEnd_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public boolean hasYEnd() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public double getYEnd() {
                return this.yEnd_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setYEnd(double d) {
                this.bitField0_ |= 8;
                this.yEnd_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearYEnd() {
                this.bitField0_ &= -9;
                this.yEnd_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public boolean hasNormalized() {
                return (this.bitField0_ & 16) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
            public boolean getNormalized() {
                return this.normalized_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNormalized(boolean z) {
                this.bitField0_ |= 16;
                this.normalized_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNormalized() {
                this.bitField0_ &= -17;
                this.normalized_ = false;
            }

            public static Arrow parseFrom(ByteBuffer byteBuffer) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Arrow parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Arrow parseFrom(ByteString byteString) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Arrow parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Arrow parseFrom(byte[] bArr) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Arrow parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Arrow parseFrom(InputStream inputStream) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Arrow parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Arrow parseDelimitedFrom(InputStream inputStream) {
                return (Arrow) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Arrow parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Arrow) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Arrow parseFrom(CodedInputStream codedInputStream) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Arrow parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Arrow) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Arrow arrow) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(arrow);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Arrow, Builder> implements ArrowOrBuilder {
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
                    super(Arrow.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public boolean hasXStart() {
                    return ((Arrow) this.instance).hasXStart();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public double getXStart() {
                    return ((Arrow) this.instance).getXStart();
                }

                public Builder setXStart(double d) {
                    copyOnWrite();
                    ((Arrow) this.instance).setXStart(d);
                    return this;
                }

                public Builder clearXStart() {
                    copyOnWrite();
                    ((Arrow) this.instance).clearXStart();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public boolean hasYStart() {
                    return ((Arrow) this.instance).hasYStart();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public double getYStart() {
                    return ((Arrow) this.instance).getYStart();
                }

                public Builder setYStart(double d) {
                    copyOnWrite();
                    ((Arrow) this.instance).setYStart(d);
                    return this;
                }

                public Builder clearYStart() {
                    copyOnWrite();
                    ((Arrow) this.instance).clearYStart();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public boolean hasXEnd() {
                    return ((Arrow) this.instance).hasXEnd();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public double getXEnd() {
                    return ((Arrow) this.instance).getXEnd();
                }

                public Builder setXEnd(double d) {
                    copyOnWrite();
                    ((Arrow) this.instance).setXEnd(d);
                    return this;
                }

                public Builder clearXEnd() {
                    copyOnWrite();
                    ((Arrow) this.instance).clearXEnd();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public boolean hasYEnd() {
                    return ((Arrow) this.instance).hasYEnd();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public double getYEnd() {
                    return ((Arrow) this.instance).getYEnd();
                }

                public Builder setYEnd(double d) {
                    copyOnWrite();
                    ((Arrow) this.instance).setYEnd(d);
                    return this;
                }

                public Builder clearYEnd() {
                    copyOnWrite();
                    ((Arrow) this.instance).clearYEnd();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public boolean hasNormalized() {
                    return ((Arrow) this.instance).hasNormalized();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.ArrowOrBuilder
                public boolean getNormalized() {
                    return ((Arrow) this.instance).getNormalized();
                }

                public Builder setNormalized(boolean z) {
                    copyOnWrite();
                    ((Arrow) this.instance).setNormalized(z);
                    return this;
                }

                public Builder clearNormalized() {
                    copyOnWrite();
                    ((Arrow) this.instance).clearNormalized();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Arrow();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0005\u0000\u0001\u0001\u0005\u0005\u0000\u0000\u0000\u0001က\u0000\u0002က\u0001\u0003က\u0002\u0004က\u0003\u0005ဇ\u0004", new Object[]{"bitField0_", "xStart_", "yStart_", "xEnd_", "yEnd_", "normalized_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Arrow> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Arrow.class) {
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
                Arrow arrow = new Arrow();
                DEFAULT_INSTANCE = arrow;
                GeneratedMessageLite.registerDefaultInstance(Arrow.class, arrow);
            }

            public static Arrow getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Arrow> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public static final class Text extends GeneratedMessageLite<Text, Builder> implements TextOrBuilder {
            public static final int BASELINE_FIELD_NUMBER = 3;
            public static final int CENTER_HORIZONTALLY_FIELD_NUMBER = 7;
            public static final int CENTER_VERTICALLY_FIELD_NUMBER = 8;
            private static final Text DEFAULT_INSTANCE;
            public static final int DISPLAY_TEXT_FIELD_NUMBER = 1;
            public static final int FONT_FACE_FIELD_NUMBER = 6;
            public static final int FONT_HEIGHT_FIELD_NUMBER = 4;
            public static final int LEFT_FIELD_NUMBER = 2;
            public static final int NORMALIZED_FIELD_NUMBER = 5;
            public static final int OUTLINE_COLOR_FIELD_NUMBER = 12;
            public static final int OUTLINE_THICKNESS_FIELD_NUMBER = 11;
            private static volatile Parser<Text> PARSER;
            private double baseline_;
            private int bitField0_;
            private boolean centerHorizontally_;
            private boolean centerVertically_;
            private int fontFace_;
            private double left_;
            private boolean normalized_;
            private ColorProto.Color outlineColor_;
            private double outlineThickness_;
            private String displayText_ = "";
            private double fontHeight_ = 8.0d;

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

            private Text() {
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasDisplayText() {
                return (this.bitField0_ & 1) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public String getDisplayText() {
                return this.displayText_;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public ByteString getDisplayTextBytes() {
                return ByteString.copyFromUtf8(this.displayText_);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setDisplayText(String str) {
                str.getClass();
                this.bitField0_ |= 1;
                this.displayText_ = str;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearDisplayText() {
                this.bitField0_ &= -2;
                this.displayText_ = getDefaultInstance().getDisplayText();
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setDisplayTextBytes(ByteString byteString) {
                this.displayText_ = byteString.toStringUtf8();
                this.bitField0_ |= 1;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasLeft() {
                return (this.bitField0_ & 2) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public double getLeft() {
                return this.left_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setLeft(double d) {
                this.bitField0_ |= 2;
                this.left_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearLeft() {
                this.bitField0_ &= -3;
                this.left_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasBaseline() {
                return (this.bitField0_ & 4) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public double getBaseline() {
                return this.baseline_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setBaseline(double d) {
                this.bitField0_ |= 4;
                this.baseline_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearBaseline() {
                this.bitField0_ &= -5;
                this.baseline_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasFontHeight() {
                return (this.bitField0_ & 8) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public double getFontHeight() {
                return this.fontHeight_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setFontHeight(double d) {
                this.bitField0_ |= 8;
                this.fontHeight_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearFontHeight() {
                this.bitField0_ &= -9;
                this.fontHeight_ = 8.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasNormalized() {
                return (this.bitField0_ & 16) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean getNormalized() {
                return this.normalized_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setNormalized(boolean z) {
                this.bitField0_ |= 16;
                this.normalized_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearNormalized() {
                this.bitField0_ &= -17;
                this.normalized_ = false;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasFontFace() {
                return (this.bitField0_ & 32) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public int getFontFace() {
                return this.fontFace_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setFontFace(int i) {
                this.bitField0_ |= 32;
                this.fontFace_ = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearFontFace() {
                this.bitField0_ &= -33;
                this.fontFace_ = 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasCenterHorizontally() {
                return (this.bitField0_ & 64) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean getCenterHorizontally() {
                return this.centerHorizontally_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setCenterHorizontally(boolean z) {
                this.bitField0_ |= 64;
                this.centerHorizontally_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearCenterHorizontally() {
                this.bitField0_ &= -65;
                this.centerHorizontally_ = false;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasCenterVertically() {
                return (this.bitField0_ & 128) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean getCenterVertically() {
                return this.centerVertically_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setCenterVertically(boolean z) {
                this.bitField0_ |= 128;
                this.centerVertically_ = z;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearCenterVertically() {
                this.bitField0_ &= -129;
                this.centerVertically_ = false;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasOutlineThickness() {
                return (this.bitField0_ & 256) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public double getOutlineThickness() {
                return this.outlineThickness_;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOutlineThickness(double d) {
                this.bitField0_ |= 256;
                this.outlineThickness_ = d;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutlineThickness() {
                this.bitField0_ &= -257;
                this.outlineThickness_ = 0.0d;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public boolean hasOutlineColor() {
                return (this.bitField0_ & 512) != 0;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
            public ColorProto.Color getOutlineColor() {
                ColorProto.Color color = this.outlineColor_;
                return color == null ? ColorProto.Color.getDefaultInstance() : color;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void setOutlineColor(ColorProto.Color color) {
                color.getClass();
                this.outlineColor_ = color;
                this.bitField0_ |= 512;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void mergeOutlineColor(ColorProto.Color color) {
                color.getClass();
                ColorProto.Color color2 = this.outlineColor_;
                if (color2 != null && color2 != ColorProto.Color.getDefaultInstance()) {
                    this.outlineColor_ = ColorProto.Color.newBuilder(this.outlineColor_).mergeFrom(color).buildPartial();
                } else {
                    this.outlineColor_ = color;
                }
                this.bitField0_ |= 512;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public void clearOutlineColor() {
                this.outlineColor_ = null;
                this.bitField0_ &= -513;
            }

            public static Text parseFrom(ByteBuffer byteBuffer) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
            }

            public static Text parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
            }

            public static Text parseFrom(ByteString byteString) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
            }

            public static Text parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
            }

            public static Text parseFrom(byte[] bArr) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
            }

            public static Text parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
            }

            public static Text parseFrom(InputStream inputStream) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Text parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Text parseDelimitedFrom(InputStream inputStream) {
                return (Text) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
            }

            public static Text parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Text) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
            }

            public static Text parseFrom(CodedInputStream codedInputStream) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
            }

            public static Text parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
                return (Text) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
            }

            public static Builder newBuilder() {
                return (Builder) DEFAULT_INSTANCE.createBuilder();
            }

            public static Builder newBuilder(Text text) {
                return (Builder) DEFAULT_INSTANCE.createBuilder(text);
            }

            public static final class Builder extends GeneratedMessageLite.Builder<Text, Builder> implements TextOrBuilder {
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
                    super(Text.DEFAULT_INSTANCE);
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasDisplayText() {
                    return ((Text) this.instance).hasDisplayText();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public String getDisplayText() {
                    return ((Text) this.instance).getDisplayText();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public ByteString getDisplayTextBytes() {
                    return ((Text) this.instance).getDisplayTextBytes();
                }

                public Builder setDisplayText(String str) {
                    copyOnWrite();
                    ((Text) this.instance).setDisplayText(str);
                    return this;
                }

                public Builder clearDisplayText() {
                    copyOnWrite();
                    ((Text) this.instance).clearDisplayText();
                    return this;
                }

                public Builder setDisplayTextBytes(ByteString byteString) {
                    copyOnWrite();
                    ((Text) this.instance).setDisplayTextBytes(byteString);
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasLeft() {
                    return ((Text) this.instance).hasLeft();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public double getLeft() {
                    return ((Text) this.instance).getLeft();
                }

                public Builder setLeft(double d) {
                    copyOnWrite();
                    ((Text) this.instance).setLeft(d);
                    return this;
                }

                public Builder clearLeft() {
                    copyOnWrite();
                    ((Text) this.instance).clearLeft();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasBaseline() {
                    return ((Text) this.instance).hasBaseline();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public double getBaseline() {
                    return ((Text) this.instance).getBaseline();
                }

                public Builder setBaseline(double d) {
                    copyOnWrite();
                    ((Text) this.instance).setBaseline(d);
                    return this;
                }

                public Builder clearBaseline() {
                    copyOnWrite();
                    ((Text) this.instance).clearBaseline();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasFontHeight() {
                    return ((Text) this.instance).hasFontHeight();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public double getFontHeight() {
                    return ((Text) this.instance).getFontHeight();
                }

                public Builder setFontHeight(double d) {
                    copyOnWrite();
                    ((Text) this.instance).setFontHeight(d);
                    return this;
                }

                public Builder clearFontHeight() {
                    copyOnWrite();
                    ((Text) this.instance).clearFontHeight();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasNormalized() {
                    return ((Text) this.instance).hasNormalized();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean getNormalized() {
                    return ((Text) this.instance).getNormalized();
                }

                public Builder setNormalized(boolean z) {
                    copyOnWrite();
                    ((Text) this.instance).setNormalized(z);
                    return this;
                }

                public Builder clearNormalized() {
                    copyOnWrite();
                    ((Text) this.instance).clearNormalized();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasFontFace() {
                    return ((Text) this.instance).hasFontFace();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public int getFontFace() {
                    return ((Text) this.instance).getFontFace();
                }

                public Builder setFontFace(int i) {
                    copyOnWrite();
                    ((Text) this.instance).setFontFace(i);
                    return this;
                }

                public Builder clearFontFace() {
                    copyOnWrite();
                    ((Text) this.instance).clearFontFace();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasCenterHorizontally() {
                    return ((Text) this.instance).hasCenterHorizontally();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean getCenterHorizontally() {
                    return ((Text) this.instance).getCenterHorizontally();
                }

                public Builder setCenterHorizontally(boolean z) {
                    copyOnWrite();
                    ((Text) this.instance).setCenterHorizontally(z);
                    return this;
                }

                public Builder clearCenterHorizontally() {
                    copyOnWrite();
                    ((Text) this.instance).clearCenterHorizontally();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasCenterVertically() {
                    return ((Text) this.instance).hasCenterVertically();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean getCenterVertically() {
                    return ((Text) this.instance).getCenterVertically();
                }

                public Builder setCenterVertically(boolean z) {
                    copyOnWrite();
                    ((Text) this.instance).setCenterVertically(z);
                    return this;
                }

                public Builder clearCenterVertically() {
                    copyOnWrite();
                    ((Text) this.instance).clearCenterVertically();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasOutlineThickness() {
                    return ((Text) this.instance).hasOutlineThickness();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public double getOutlineThickness() {
                    return ((Text) this.instance).getOutlineThickness();
                }

                public Builder setOutlineThickness(double d) {
                    copyOnWrite();
                    ((Text) this.instance).setOutlineThickness(d);
                    return this;
                }

                public Builder clearOutlineThickness() {
                    copyOnWrite();
                    ((Text) this.instance).clearOutlineThickness();
                    return this;
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public boolean hasOutlineColor() {
                    return ((Text) this.instance).hasOutlineColor();
                }

                @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotation.TextOrBuilder
                public ColorProto.Color getOutlineColor() {
                    return ((Text) this.instance).getOutlineColor();
                }

                public Builder setOutlineColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((Text) this.instance).setOutlineColor(color);
                    return this;
                }

                public Builder setOutlineColor(ColorProto.Color.Builder builder) {
                    copyOnWrite();
                    ((Text) this.instance).setOutlineColor(builder.build());
                    return this;
                }

                public Builder mergeOutlineColor(ColorProto.Color color) {
                    copyOnWrite();
                    ((Text) this.instance).mergeOutlineColor(color);
                    return this;
                }

                public Builder clearOutlineColor() {
                    copyOnWrite();
                    ((Text) this.instance).clearOutlineColor();
                    return this;
                }
            }

            @Override // com.google.protobuf.GeneratedMessageLite
            protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
                Parser defaultInstanceBasedParser;
                AnonymousClass1 anonymousClass1 = null;
                switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                    case 1:
                        return new Text();
                    case 2:
                        return new Builder(anonymousClass1);
                    case 3:
                        return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\n\u0000\u0001\u0001\f\n\u0000\u0000\u0000\u0001ဈ\u0000\u0002က\u0001\u0003က\u0002\u0004က\u0003\u0005ဇ\u0004\u0006င\u0005\u0007ဇ\u0006\bဇ\u0007\u000bက\b\fဉ\t", new Object[]{"bitField0_", "displayText_", "left_", "baseline_", "fontHeight_", "normalized_", "fontFace_", "centerHorizontally_", "centerVertically_", "outlineThickness_", "outlineColor_"});
                    case 4:
                        return DEFAULT_INSTANCE;
                    case 5:
                        Parser<Text> parser = PARSER;
                        if (parser != null) {
                            return parser;
                        }
                        synchronized (Text.class) {
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
                Text text = new Text();
                DEFAULT_INSTANCE = text;
                GeneratedMessageLite.registerDefaultInstance(Text.class, text);
            }

            public static Text getDefaultInstance() {
                return DEFAULT_INSTANCE;
            }

            public static Parser<Text> parser() {
                return DEFAULT_INSTANCE.getParserForType();
            }
        }

        public enum DataCase {
            RECTANGLE(1),
            FILLED_RECTANGLE(2),
            OVAL(3),
            FILLED_OVAL(4),
            POINT(5),
            LINE(6),
            ARROW(7),
            TEXT(8),
            ROUNDED_RECTANGLE(9),
            FILLED_ROUNDED_RECTANGLE(10),
            GRADIENT_LINE(14),
            SCRIBBLE(15),
            DATA_NOT_SET(0);

            private final int value;

            DataCase(int i) {
                this.value = i;
            }

            @Deprecated
            public static DataCase valueOf(int i) {
                return forNumber(i);
            }

            public static DataCase forNumber(int i) {
                if (i == 14) {
                    return GRADIENT_LINE;
                }
                if (i == 15) {
                    return SCRIBBLE;
                }
                switch (i) {
                    case 0:
                        return DATA_NOT_SET;
                    case 1:
                        return RECTANGLE;
                    case 2:
                        return FILLED_RECTANGLE;
                    case 3:
                        return OVAL;
                    case 4:
                        return FILLED_OVAL;
                    case 5:
                        return POINT;
                    case 6:
                        return LINE;
                    case 7:
                        return ARROW;
                    case 8:
                        return TEXT;
                    case 9:
                        return ROUNDED_RECTANGLE;
                    case 10:
                        return FILLED_ROUNDED_RECTANGLE;
                    default:
                        return null;
                }
            }

            public int getNumber() {
                return this.value;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public DataCase getDataCase() {
            return DataCase.forNumber(this.dataCase_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearData() {
            this.dataCase_ = 0;
            this.data_ = null;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasRectangle() {
            return this.dataCase_ == 1;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public Rectangle getRectangle() {
            if (this.dataCase_ == 1) {
                return (Rectangle) this.data_;
            }
            return Rectangle.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRectangle(Rectangle rectangle) {
            rectangle.getClass();
            this.data_ = rectangle;
            this.dataCase_ = 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeRectangle(Rectangle rectangle) {
            rectangle.getClass();
            if (this.dataCase_ == 1 && this.data_ != Rectangle.getDefaultInstance()) {
                this.data_ = Rectangle.newBuilder((Rectangle) this.data_).mergeFrom(rectangle).buildPartial();
            } else {
                this.data_ = rectangle;
            }
            this.dataCase_ = 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRectangle() {
            if (this.dataCase_ == 1) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasFilledRectangle() {
            return this.dataCase_ == 2;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public FilledRectangle getFilledRectangle() {
            if (this.dataCase_ == 2) {
                return (FilledRectangle) this.data_;
            }
            return FilledRectangle.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFilledRectangle(FilledRectangle filledRectangle) {
            filledRectangle.getClass();
            this.data_ = filledRectangle;
            this.dataCase_ = 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFilledRectangle(FilledRectangle filledRectangle) {
            filledRectangle.getClass();
            if (this.dataCase_ == 2 && this.data_ != FilledRectangle.getDefaultInstance()) {
                this.data_ = FilledRectangle.newBuilder((FilledRectangle) this.data_).mergeFrom(filledRectangle).buildPartial();
            } else {
                this.data_ = filledRectangle;
            }
            this.dataCase_ = 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFilledRectangle() {
            if (this.dataCase_ == 2) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasOval() {
            return this.dataCase_ == 3;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public Oval getOval() {
            if (this.dataCase_ == 3) {
                return (Oval) this.data_;
            }
            return Oval.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOval(Oval oval) {
            oval.getClass();
            this.data_ = oval;
            this.dataCase_ = 3;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeOval(Oval oval) {
            oval.getClass();
            if (this.dataCase_ == 3 && this.data_ != Oval.getDefaultInstance()) {
                this.data_ = Oval.newBuilder((Oval) this.data_).mergeFrom(oval).buildPartial();
            } else {
                this.data_ = oval;
            }
            this.dataCase_ = 3;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOval() {
            if (this.dataCase_ == 3) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasFilledOval() {
            return this.dataCase_ == 4;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public FilledOval getFilledOval() {
            if (this.dataCase_ == 4) {
                return (FilledOval) this.data_;
            }
            return FilledOval.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFilledOval(FilledOval filledOval) {
            filledOval.getClass();
            this.data_ = filledOval;
            this.dataCase_ = 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFilledOval(FilledOval filledOval) {
            filledOval.getClass();
            if (this.dataCase_ == 4 && this.data_ != FilledOval.getDefaultInstance()) {
                this.data_ = FilledOval.newBuilder((FilledOval) this.data_).mergeFrom(filledOval).buildPartial();
            } else {
                this.data_ = filledOval;
            }
            this.dataCase_ = 4;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFilledOval() {
            if (this.dataCase_ == 4) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasPoint() {
            return this.dataCase_ == 5;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public Point getPoint() {
            if (this.dataCase_ == 5) {
                return (Point) this.data_;
            }
            return Point.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPoint(Point point) {
            point.getClass();
            this.data_ = point;
            this.dataCase_ = 5;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergePoint(Point point) {
            point.getClass();
            if (this.dataCase_ == 5 && this.data_ != Point.getDefaultInstance()) {
                this.data_ = Point.newBuilder((Point) this.data_).mergeFrom(point).buildPartial();
            } else {
                this.data_ = point;
            }
            this.dataCase_ = 5;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPoint() {
            if (this.dataCase_ == 5) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasLine() {
            return this.dataCase_ == 6;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public Line getLine() {
            if (this.dataCase_ == 6) {
                return (Line) this.data_;
            }
            return Line.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLine(Line line) {
            line.getClass();
            this.data_ = line;
            this.dataCase_ = 6;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeLine(Line line) {
            line.getClass();
            if (this.dataCase_ == 6 && this.data_ != Line.getDefaultInstance()) {
                this.data_ = Line.newBuilder((Line) this.data_).mergeFrom(line).buildPartial();
            } else {
                this.data_ = line;
            }
            this.dataCase_ = 6;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLine() {
            if (this.dataCase_ == 6) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasArrow() {
            return this.dataCase_ == 7;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public Arrow getArrow() {
            if (this.dataCase_ == 7) {
                return (Arrow) this.data_;
            }
            return Arrow.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setArrow(Arrow arrow) {
            arrow.getClass();
            this.data_ = arrow;
            this.dataCase_ = 7;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeArrow(Arrow arrow) {
            arrow.getClass();
            if (this.dataCase_ == 7 && this.data_ != Arrow.getDefaultInstance()) {
                this.data_ = Arrow.newBuilder((Arrow) this.data_).mergeFrom(arrow).buildPartial();
            } else {
                this.data_ = arrow;
            }
            this.dataCase_ = 7;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearArrow() {
            if (this.dataCase_ == 7) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasText() {
            return this.dataCase_ == 8;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public Text getText() {
            if (this.dataCase_ == 8) {
                return (Text) this.data_;
            }
            return Text.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setText(Text text) {
            text.getClass();
            this.data_ = text;
            this.dataCase_ = 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeText(Text text) {
            text.getClass();
            if (this.dataCase_ == 8 && this.data_ != Text.getDefaultInstance()) {
                this.data_ = Text.newBuilder((Text) this.data_).mergeFrom(text).buildPartial();
            } else {
                this.data_ = text;
            }
            this.dataCase_ = 8;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearText() {
            if (this.dataCase_ == 8) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasRoundedRectangle() {
            return this.dataCase_ == 9;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public RoundedRectangle getRoundedRectangle() {
            if (this.dataCase_ == 9) {
                return (RoundedRectangle) this.data_;
            }
            return RoundedRectangle.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setRoundedRectangle(RoundedRectangle roundedRectangle) {
            roundedRectangle.getClass();
            this.data_ = roundedRectangle;
            this.dataCase_ = 9;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeRoundedRectangle(RoundedRectangle roundedRectangle) {
            roundedRectangle.getClass();
            if (this.dataCase_ == 9 && this.data_ != RoundedRectangle.getDefaultInstance()) {
                this.data_ = RoundedRectangle.newBuilder((RoundedRectangle) this.data_).mergeFrom(roundedRectangle).buildPartial();
            } else {
                this.data_ = roundedRectangle;
            }
            this.dataCase_ = 9;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearRoundedRectangle() {
            if (this.dataCase_ == 9) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasFilledRoundedRectangle() {
            return this.dataCase_ == 10;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public FilledRoundedRectangle getFilledRoundedRectangle() {
            if (this.dataCase_ == 10) {
                return (FilledRoundedRectangle) this.data_;
            }
            return FilledRoundedRectangle.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFilledRoundedRectangle(FilledRoundedRectangle filledRoundedRectangle) {
            filledRoundedRectangle.getClass();
            this.data_ = filledRoundedRectangle;
            this.dataCase_ = 10;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeFilledRoundedRectangle(FilledRoundedRectangle filledRoundedRectangle) {
            filledRoundedRectangle.getClass();
            if (this.dataCase_ == 10 && this.data_ != FilledRoundedRectangle.getDefaultInstance()) {
                this.data_ = FilledRoundedRectangle.newBuilder((FilledRoundedRectangle) this.data_).mergeFrom(filledRoundedRectangle).buildPartial();
            } else {
                this.data_ = filledRoundedRectangle;
            }
            this.dataCase_ = 10;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFilledRoundedRectangle() {
            if (this.dataCase_ == 10) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasGradientLine() {
            return this.dataCase_ == 14;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public GradientLine getGradientLine() {
            if (this.dataCase_ == 14) {
                return (GradientLine) this.data_;
            }
            return GradientLine.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setGradientLine(GradientLine gradientLine) {
            gradientLine.getClass();
            this.data_ = gradientLine;
            this.dataCase_ = 14;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeGradientLine(GradientLine gradientLine) {
            gradientLine.getClass();
            if (this.dataCase_ == 14 && this.data_ != GradientLine.getDefaultInstance()) {
                this.data_ = GradientLine.newBuilder((GradientLine) this.data_).mergeFrom(gradientLine).buildPartial();
            } else {
                this.data_ = gradientLine;
            }
            this.dataCase_ = 14;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearGradientLine() {
            if (this.dataCase_ == 14) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasScribble() {
            return this.dataCase_ == 15;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public Scribble getScribble() {
            if (this.dataCase_ == 15) {
                return (Scribble) this.data_;
            }
            return Scribble.getDefaultInstance();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setScribble(Scribble scribble) {
            scribble.getClass();
            this.data_ = scribble;
            this.dataCase_ = 15;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeScribble(Scribble scribble) {
            scribble.getClass();
            if (this.dataCase_ == 15 && this.data_ != Scribble.getDefaultInstance()) {
                this.data_ = Scribble.newBuilder((Scribble) this.data_).mergeFrom(scribble).buildPartial();
            } else {
                this.data_ = scribble;
            }
            this.dataCase_ = 15;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearScribble() {
            if (this.dataCase_ == 15) {
                this.dataCase_ = 0;
                this.data_ = null;
            }
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasThickness() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public double getThickness() {
            return this.thickness_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setThickness(double d) {
            this.bitField0_ |= 1;
            this.thickness_ = d;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearThickness() {
            this.bitField0_ &= -2;
            this.thickness_ = 1.0d;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasColor() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public ColorProto.Color getColor() {
            ColorProto.Color color = this.color_;
            return color == null ? ColorProto.Color.getDefaultInstance() : color;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setColor(ColorProto.Color color) {
            color.getClass();
            this.color_ = color;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeColor(ColorProto.Color color) {
            color.getClass();
            ColorProto.Color color2 = this.color_;
            if (color2 != null && color2 != ColorProto.Color.getDefaultInstance()) {
                this.color_ = ColorProto.Color.newBuilder(this.color_).mergeFrom(color).buildPartial();
            } else {
                this.color_ = color;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearColor() {
            this.color_ = null;
            this.bitField0_ &= -3;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public boolean hasSceneTag() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public String getSceneTag() {
            return this.sceneTag_;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
        public ByteString getSceneTagBytes() {
            return ByteString.copyFromUtf8(this.sceneTag_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setSceneTag(String str) {
            str.getClass();
            this.bitField0_ |= 4;
            this.sceneTag_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearSceneTag() {
            this.bitField0_ &= -5;
            this.sceneTag_ = getDefaultInstance().getSceneTag();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setSceneTagBytes(ByteString byteString) {
            this.sceneTag_ = byteString.toStringUtf8();
            this.bitField0_ |= 4;
        }

        public static RenderAnnotation parseFrom(ByteBuffer byteBuffer) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static RenderAnnotation parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static RenderAnnotation parseFrom(ByteString byteString) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static RenderAnnotation parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static RenderAnnotation parseFrom(byte[] bArr) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static RenderAnnotation parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static RenderAnnotation parseFrom(InputStream inputStream) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RenderAnnotation parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RenderAnnotation parseDelimitedFrom(InputStream inputStream) {
            return (RenderAnnotation) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RenderAnnotation parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderAnnotation) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RenderAnnotation parseFrom(CodedInputStream codedInputStream) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static RenderAnnotation parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderAnnotation) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(RenderAnnotation renderAnnotation) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(renderAnnotation);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<RenderAnnotation, Builder> implements RenderAnnotationOrBuilder {
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
                super(RenderAnnotation.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public DataCase getDataCase() {
                return ((RenderAnnotation) this.instance).getDataCase();
            }

            public Builder clearData() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearData();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasRectangle() {
                return ((RenderAnnotation) this.instance).hasRectangle();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public Rectangle getRectangle() {
                return ((RenderAnnotation) this.instance).getRectangle();
            }

            public Builder setRectangle(Rectangle rectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setRectangle(rectangle);
                return this;
            }

            public Builder setRectangle(Rectangle.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setRectangle(builder.build());
                return this;
            }

            public Builder mergeRectangle(Rectangle rectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeRectangle(rectangle);
                return this;
            }

            public Builder clearRectangle() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearRectangle();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasFilledRectangle() {
                return ((RenderAnnotation) this.instance).hasFilledRectangle();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public FilledRectangle getFilledRectangle() {
                return ((RenderAnnotation) this.instance).getFilledRectangle();
            }

            public Builder setFilledRectangle(FilledRectangle filledRectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setFilledRectangle(filledRectangle);
                return this;
            }

            public Builder setFilledRectangle(FilledRectangle.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setFilledRectangle(builder.build());
                return this;
            }

            public Builder mergeFilledRectangle(FilledRectangle filledRectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeFilledRectangle(filledRectangle);
                return this;
            }

            public Builder clearFilledRectangle() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearFilledRectangle();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasOval() {
                return ((RenderAnnotation) this.instance).hasOval();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public Oval getOval() {
                return ((RenderAnnotation) this.instance).getOval();
            }

            public Builder setOval(Oval oval) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setOval(oval);
                return this;
            }

            public Builder setOval(Oval.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setOval(builder.build());
                return this;
            }

            public Builder mergeOval(Oval oval) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeOval(oval);
                return this;
            }

            public Builder clearOval() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearOval();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasFilledOval() {
                return ((RenderAnnotation) this.instance).hasFilledOval();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public FilledOval getFilledOval() {
                return ((RenderAnnotation) this.instance).getFilledOval();
            }

            public Builder setFilledOval(FilledOval filledOval) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setFilledOval(filledOval);
                return this;
            }

            public Builder setFilledOval(FilledOval.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setFilledOval(builder.build());
                return this;
            }

            public Builder mergeFilledOval(FilledOval filledOval) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeFilledOval(filledOval);
                return this;
            }

            public Builder clearFilledOval() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearFilledOval();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasPoint() {
                return ((RenderAnnotation) this.instance).hasPoint();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public Point getPoint() {
                return ((RenderAnnotation) this.instance).getPoint();
            }

            public Builder setPoint(Point point) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setPoint(point);
                return this;
            }

            public Builder setPoint(Point.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setPoint(builder.build());
                return this;
            }

            public Builder mergePoint(Point point) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergePoint(point);
                return this;
            }

            public Builder clearPoint() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearPoint();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasLine() {
                return ((RenderAnnotation) this.instance).hasLine();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public Line getLine() {
                return ((RenderAnnotation) this.instance).getLine();
            }

            public Builder setLine(Line line) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setLine(line);
                return this;
            }

            public Builder setLine(Line.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setLine(builder.build());
                return this;
            }

            public Builder mergeLine(Line line) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeLine(line);
                return this;
            }

            public Builder clearLine() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearLine();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasArrow() {
                return ((RenderAnnotation) this.instance).hasArrow();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public Arrow getArrow() {
                return ((RenderAnnotation) this.instance).getArrow();
            }

            public Builder setArrow(Arrow arrow) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setArrow(arrow);
                return this;
            }

            public Builder setArrow(Arrow.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setArrow(builder.build());
                return this;
            }

            public Builder mergeArrow(Arrow arrow) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeArrow(arrow);
                return this;
            }

            public Builder clearArrow() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearArrow();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasText() {
                return ((RenderAnnotation) this.instance).hasText();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public Text getText() {
                return ((RenderAnnotation) this.instance).getText();
            }

            public Builder setText(Text text) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setText(text);
                return this;
            }

            public Builder setText(Text.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setText(builder.build());
                return this;
            }

            public Builder mergeText(Text text) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeText(text);
                return this;
            }

            public Builder clearText() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearText();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasRoundedRectangle() {
                return ((RenderAnnotation) this.instance).hasRoundedRectangle();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public RoundedRectangle getRoundedRectangle() {
                return ((RenderAnnotation) this.instance).getRoundedRectangle();
            }

            public Builder setRoundedRectangle(RoundedRectangle roundedRectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setRoundedRectangle(roundedRectangle);
                return this;
            }

            public Builder setRoundedRectangle(RoundedRectangle.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setRoundedRectangle(builder.build());
                return this;
            }

            public Builder mergeRoundedRectangle(RoundedRectangle roundedRectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeRoundedRectangle(roundedRectangle);
                return this;
            }

            public Builder clearRoundedRectangle() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearRoundedRectangle();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasFilledRoundedRectangle() {
                return ((RenderAnnotation) this.instance).hasFilledRoundedRectangle();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public FilledRoundedRectangle getFilledRoundedRectangle() {
                return ((RenderAnnotation) this.instance).getFilledRoundedRectangle();
            }

            public Builder setFilledRoundedRectangle(FilledRoundedRectangle filledRoundedRectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setFilledRoundedRectangle(filledRoundedRectangle);
                return this;
            }

            public Builder setFilledRoundedRectangle(FilledRoundedRectangle.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setFilledRoundedRectangle(builder.build());
                return this;
            }

            public Builder mergeFilledRoundedRectangle(FilledRoundedRectangle filledRoundedRectangle) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeFilledRoundedRectangle(filledRoundedRectangle);
                return this;
            }

            public Builder clearFilledRoundedRectangle() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearFilledRoundedRectangle();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasGradientLine() {
                return ((RenderAnnotation) this.instance).hasGradientLine();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public GradientLine getGradientLine() {
                return ((RenderAnnotation) this.instance).getGradientLine();
            }

            public Builder setGradientLine(GradientLine gradientLine) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setGradientLine(gradientLine);
                return this;
            }

            public Builder setGradientLine(GradientLine.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setGradientLine(builder.build());
                return this;
            }

            public Builder mergeGradientLine(GradientLine gradientLine) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeGradientLine(gradientLine);
                return this;
            }

            public Builder clearGradientLine() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearGradientLine();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasScribble() {
                return ((RenderAnnotation) this.instance).hasScribble();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public Scribble getScribble() {
                return ((RenderAnnotation) this.instance).getScribble();
            }

            public Builder setScribble(Scribble scribble) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setScribble(scribble);
                return this;
            }

            public Builder setScribble(Scribble.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setScribble(builder.build());
                return this;
            }

            public Builder mergeScribble(Scribble scribble) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeScribble(scribble);
                return this;
            }

            public Builder clearScribble() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearScribble();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasThickness() {
                return ((RenderAnnotation) this.instance).hasThickness();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public double getThickness() {
                return ((RenderAnnotation) this.instance).getThickness();
            }

            public Builder setThickness(double d) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setThickness(d);
                return this;
            }

            public Builder clearThickness() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearThickness();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasColor() {
                return ((RenderAnnotation) this.instance).hasColor();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public ColorProto.Color getColor() {
                return ((RenderAnnotation) this.instance).getColor();
            }

            public Builder setColor(ColorProto.Color color) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setColor(color);
                return this;
            }

            public Builder setColor(ColorProto.Color.Builder builder) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setColor(builder.build());
                return this;
            }

            public Builder mergeColor(ColorProto.Color color) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).mergeColor(color);
                return this;
            }

            public Builder clearColor() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearColor();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public boolean hasSceneTag() {
                return ((RenderAnnotation) this.instance).hasSceneTag();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public String getSceneTag() {
                return ((RenderAnnotation) this.instance).getSceneTag();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderAnnotationOrBuilder
            public ByteString getSceneTagBytes() {
                return ((RenderAnnotation) this.instance).getSceneTagBytes();
            }

            public Builder setSceneTag(String str) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setSceneTag(str);
                return this;
            }

            public Builder clearSceneTag() {
                copyOnWrite();
                ((RenderAnnotation) this.instance).clearSceneTag();
                return this;
            }

            public Builder setSceneTagBytes(ByteString byteString) {
                copyOnWrite();
                ((RenderAnnotation) this.instance).setSceneTagBytes(byteString);
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new RenderAnnotation();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u000f\u0001\u0001\u0001\u000f\u000f\u0000\u0000\u0000\u0001<\u0000\u0002<\u0000\u0003<\u0000\u0004<\u0000\u0005<\u0000\u0006<\u0000\u0007<\u0000\b<\u0000\t<\u0000\n<\u0000\u000bက\u0000\fဉ\u0001\rဈ\u0002\u000e<\u0000\u000f<\u0000", new Object[]{"data_", "dataCase_", "bitField0_", Rectangle.class, FilledRectangle.class, Oval.class, FilledOval.class, Point.class, Line.class, Arrow.class, Text.class, RoundedRectangle.class, FilledRoundedRectangle.class, "thickness_", "color_", "sceneTag_", GradientLine.class, Scribble.class});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<RenderAnnotation> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (RenderAnnotation.class) {
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
            RenderAnnotation renderAnnotation = new RenderAnnotation();
            DEFAULT_INSTANCE = renderAnnotation;
            GeneratedMessageLite.registerDefaultInstance(RenderAnnotation.class, renderAnnotation);
        }

        public static RenderAnnotation getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<RenderAnnotation> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    public static final class RenderViewport extends GeneratedMessageLite<RenderViewport, Builder> implements RenderViewportOrBuilder {
        public static final int COMPOSE_ON_VIDEO_FIELD_NUMBER = 4;
        private static final RenderViewport DEFAULT_INSTANCE;
        public static final int HEIGHT_PX_FIELD_NUMBER = 3;
        public static final int ID_FIELD_NUMBER = 1;
        private static volatile Parser<RenderViewport> PARSER = null;
        public static final int WIDTH_PX_FIELD_NUMBER = 2;
        private int bitField0_;
        private boolean composeOnVideo_;
        private int heightPx_;
        private String id_ = "";
        private int widthPx_;

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

        private RenderViewport() {
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public boolean hasId() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public String getId() {
            return this.id_;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public ByteString getIdBytes() {
            return ByteString.copyFromUtf8(this.id_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setId(String str) {
            str.getClass();
            this.bitField0_ |= 1;
            this.id_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearId() {
            this.bitField0_ &= -2;
            this.id_ = getDefaultInstance().getId();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setIdBytes(ByteString byteString) {
            this.id_ = byteString.toStringUtf8();
            this.bitField0_ |= 1;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public boolean hasWidthPx() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public int getWidthPx() {
            return this.widthPx_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setWidthPx(int i) {
            this.bitField0_ |= 2;
            this.widthPx_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearWidthPx() {
            this.bitField0_ &= -3;
            this.widthPx_ = 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public boolean hasHeightPx() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public int getHeightPx() {
            return this.heightPx_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setHeightPx(int i) {
            this.bitField0_ |= 4;
            this.heightPx_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearHeightPx() {
            this.bitField0_ &= -5;
            this.heightPx_ = 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public boolean hasComposeOnVideo() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
        public boolean getComposeOnVideo() {
            return this.composeOnVideo_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setComposeOnVideo(boolean z) {
            this.bitField0_ |= 8;
            this.composeOnVideo_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearComposeOnVideo() {
            this.bitField0_ &= -9;
            this.composeOnVideo_ = false;
        }

        public static RenderViewport parseFrom(ByteBuffer byteBuffer) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static RenderViewport parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static RenderViewport parseFrom(ByteString byteString) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static RenderViewport parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static RenderViewport parseFrom(byte[] bArr) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static RenderViewport parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static RenderViewport parseFrom(InputStream inputStream) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RenderViewport parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RenderViewport parseDelimitedFrom(InputStream inputStream) {
            return (RenderViewport) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static RenderViewport parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderViewport) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static RenderViewport parseFrom(CodedInputStream codedInputStream) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static RenderViewport parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (RenderViewport) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(RenderViewport renderViewport) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(renderViewport);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<RenderViewport, Builder> implements RenderViewportOrBuilder {
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
                super(RenderViewport.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public boolean hasId() {
                return ((RenderViewport) this.instance).hasId();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public String getId() {
                return ((RenderViewport) this.instance).getId();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public ByteString getIdBytes() {
                return ((RenderViewport) this.instance).getIdBytes();
            }

            public Builder setId(String str) {
                copyOnWrite();
                ((RenderViewport) this.instance).setId(str);
                return this;
            }

            public Builder clearId() {
                copyOnWrite();
                ((RenderViewport) this.instance).clearId();
                return this;
            }

            public Builder setIdBytes(ByteString byteString) {
                copyOnWrite();
                ((RenderViewport) this.instance).setIdBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public boolean hasWidthPx() {
                return ((RenderViewport) this.instance).hasWidthPx();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public int getWidthPx() {
                return ((RenderViewport) this.instance).getWidthPx();
            }

            public Builder setWidthPx(int i) {
                copyOnWrite();
                ((RenderViewport) this.instance).setWidthPx(i);
                return this;
            }

            public Builder clearWidthPx() {
                copyOnWrite();
                ((RenderViewport) this.instance).clearWidthPx();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public boolean hasHeightPx() {
                return ((RenderViewport) this.instance).hasHeightPx();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public int getHeightPx() {
                return ((RenderViewport) this.instance).getHeightPx();
            }

            public Builder setHeightPx(int i) {
                copyOnWrite();
                ((RenderViewport) this.instance).setHeightPx(i);
                return this;
            }

            public Builder clearHeightPx() {
                copyOnWrite();
                ((RenderViewport) this.instance).clearHeightPx();
                return this;
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public boolean hasComposeOnVideo() {
                return ((RenderViewport) this.instance).hasComposeOnVideo();
            }

            @Override // com.google.mediapipe.util.proto.RenderDataProto.RenderViewportOrBuilder
            public boolean getComposeOnVideo() {
                return ((RenderViewport) this.instance).getComposeOnVideo();
            }

            public Builder setComposeOnVideo(boolean z) {
                copyOnWrite();
                ((RenderViewport) this.instance).setComposeOnVideo(z);
                return this;
            }

            public Builder clearComposeOnVideo() {
                copyOnWrite();
                ((RenderViewport) this.instance).clearComposeOnVideo();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new RenderViewport();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0000\u0000\u0001ဈ\u0000\u0002င\u0001\u0003င\u0002\u0004ဇ\u0003", new Object[]{"bitField0_", "id_", "widthPx_", "heightPx_", "composeOnVideo_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<RenderViewport> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (RenderViewport.class) {
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
            RenderViewport renderViewport = new RenderViewport();
            DEFAULT_INSTANCE = renderViewport;
            GeneratedMessageLite.registerDefaultInstance(RenderViewport.class, renderViewport);
        }

        public static RenderViewport getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<RenderViewport> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }
}
