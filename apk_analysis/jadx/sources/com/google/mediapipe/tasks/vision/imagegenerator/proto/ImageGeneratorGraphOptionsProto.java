package com.google.mediapipe.tasks.vision.imagegenerator.proto;

import com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto;
import com.google.mediapipe.tasks.core.proto.ExternalFileProto;
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
public final class ImageGeneratorGraphOptionsProto {

    public interface ImageGeneratorGraphOptionsOrBuilder extends MessageLiteOrBuilder {
        ControlPluginGraphOptionsProto.ControlPluginGraphOptions getControlPluginGraphsOptions(int i);

        int getControlPluginGraphsOptionsCount();

        List<ControlPluginGraphOptionsProto.ControlPluginGraphOptions> getControlPluginGraphsOptionsList();

        ExternalFileProto.ExternalFile getLoraWeightsFile();

        StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions getStableDiffusionIterateOptions();

        String getText2ImageModelDirectory();

        ByteString getText2ImageModelDirectoryBytes();

        boolean hasLoraWeightsFile();

        boolean hasStableDiffusionIterateOptions();
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
    }

    private ImageGeneratorGraphOptionsProto() {
    }

    public static final class ImageGeneratorGraphOptions extends GeneratedMessageLite<ImageGeneratorGraphOptions, Builder> implements ImageGeneratorGraphOptionsOrBuilder {
        public static final int CONTROL_PLUGIN_GRAPHS_OPTIONS_FIELD_NUMBER = 3;
        private static final ImageGeneratorGraphOptions DEFAULT_INSTANCE;
        public static final int LORA_WEIGHTS_FILE_FIELD_NUMBER = 2;
        private static volatile Parser<ImageGeneratorGraphOptions> PARSER = null;
        public static final int STABLE_DIFFUSION_ITERATE_OPTIONS_FIELD_NUMBER = 4;
        public static final int TEXT2IMAGE_MODEL_DIRECTORY_FIELD_NUMBER = 1;
        private int bitField0_;
        private ExternalFileProto.ExternalFile loraWeightsFile_;
        private StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions stableDiffusionIterateOptions_;
        private String text2ImageModelDirectory_ = "";
        private Internal.ProtobufList<ControlPluginGraphOptionsProto.ControlPluginGraphOptions> controlPluginGraphsOptions_ = GeneratedMessageLite.emptyProtobufList();

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

        private ImageGeneratorGraphOptions() {
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public String getText2ImageModelDirectory() {
            return this.text2ImageModelDirectory_;
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public ByteString getText2ImageModelDirectoryBytes() {
            return ByteString.copyFromUtf8(this.text2ImageModelDirectory_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setText2ImageModelDirectory(String str) {
            str.getClass();
            this.text2ImageModelDirectory_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearText2ImageModelDirectory() {
            this.text2ImageModelDirectory_ = getDefaultInstance().getText2ImageModelDirectory();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setText2ImageModelDirectoryBytes(ByteString byteString) {
            AbstractMessageLite.checkByteStringIsUtf8(byteString);
            this.text2ImageModelDirectory_ = byteString.toStringUtf8();
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public boolean hasLoraWeightsFile() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public ExternalFileProto.ExternalFile getLoraWeightsFile() {
            ExternalFileProto.ExternalFile externalFile = this.loraWeightsFile_;
            return externalFile == null ? ExternalFileProto.ExternalFile.getDefaultInstance() : externalFile;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLoraWeightsFile(ExternalFileProto.ExternalFile externalFile) {
            externalFile.getClass();
            this.loraWeightsFile_ = externalFile;
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeLoraWeightsFile(ExternalFileProto.ExternalFile externalFile) {
            externalFile.getClass();
            ExternalFileProto.ExternalFile externalFile2 = this.loraWeightsFile_;
            if (externalFile2 != null && externalFile2 != ExternalFileProto.ExternalFile.getDefaultInstance()) {
                this.loraWeightsFile_ = ExternalFileProto.ExternalFile.newBuilder(this.loraWeightsFile_).mergeFrom(externalFile).buildPartial();
            } else {
                this.loraWeightsFile_ = externalFile;
            }
            this.bitField0_ |= 1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLoraWeightsFile() {
            this.loraWeightsFile_ = null;
            this.bitField0_ &= -2;
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public List<ControlPluginGraphOptionsProto.ControlPluginGraphOptions> getControlPluginGraphsOptionsList() {
            return this.controlPluginGraphsOptions_;
        }

        public List<? extends ControlPluginGraphOptionsProto.ControlPluginGraphOptionsOrBuilder> getControlPluginGraphsOptionsOrBuilderList() {
            return this.controlPluginGraphsOptions_;
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public int getControlPluginGraphsOptionsCount() {
            return this.controlPluginGraphsOptions_.size();
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public ControlPluginGraphOptionsProto.ControlPluginGraphOptions getControlPluginGraphsOptions(int i) {
            return this.controlPluginGraphsOptions_.get(i);
        }

        public ControlPluginGraphOptionsProto.ControlPluginGraphOptionsOrBuilder getControlPluginGraphsOptionsOrBuilder(int i) {
            return this.controlPluginGraphsOptions_.get(i);
        }

        private void ensureControlPluginGraphsOptionsIsMutable() {
            Internal.ProtobufList<ControlPluginGraphOptionsProto.ControlPluginGraphOptions> protobufList = this.controlPluginGraphsOptions_;
            if (protobufList.isModifiable()) {
                return;
            }
            this.controlPluginGraphsOptions_ = GeneratedMessageLite.mutableCopy(protobufList);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setControlPluginGraphsOptions(int i, ControlPluginGraphOptionsProto.ControlPluginGraphOptions controlPluginGraphOptions) {
            controlPluginGraphOptions.getClass();
            ensureControlPluginGraphsOptionsIsMutable();
            this.controlPluginGraphsOptions_.set(i, controlPluginGraphOptions);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addControlPluginGraphsOptions(ControlPluginGraphOptionsProto.ControlPluginGraphOptions controlPluginGraphOptions) {
            controlPluginGraphOptions.getClass();
            ensureControlPluginGraphsOptionsIsMutable();
            this.controlPluginGraphsOptions_.add(controlPluginGraphOptions);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addControlPluginGraphsOptions(int i, ControlPluginGraphOptionsProto.ControlPluginGraphOptions controlPluginGraphOptions) {
            controlPluginGraphOptions.getClass();
            ensureControlPluginGraphsOptionsIsMutable();
            this.controlPluginGraphsOptions_.add(i, controlPluginGraphOptions);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void addAllControlPluginGraphsOptions(Iterable<? extends ControlPluginGraphOptionsProto.ControlPluginGraphOptions> iterable) {
            ensureControlPluginGraphsOptionsIsMutable();
            AbstractMessageLite.addAll(iterable, this.controlPluginGraphsOptions_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearControlPluginGraphsOptions() {
            this.controlPluginGraphsOptions_ = GeneratedMessageLite.emptyProtobufList();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void removeControlPluginGraphsOptions(int i) {
            ensureControlPluginGraphsOptionsIsMutable();
            this.controlPluginGraphsOptions_.remove(i);
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public boolean hasStableDiffusionIterateOptions() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
        public StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions getStableDiffusionIterateOptions() {
            StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions = this.stableDiffusionIterateOptions_;
            return stableDiffusionIterateCalculatorOptions == null ? StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions.getDefaultInstance() : stableDiffusionIterateCalculatorOptions;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setStableDiffusionIterateOptions(StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions) {
            stableDiffusionIterateCalculatorOptions.getClass();
            this.stableDiffusionIterateOptions_ = stableDiffusionIterateCalculatorOptions;
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void mergeStableDiffusionIterateOptions(StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions) {
            stableDiffusionIterateCalculatorOptions.getClass();
            StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions2 = this.stableDiffusionIterateOptions_;
            if (stableDiffusionIterateCalculatorOptions2 != null && stableDiffusionIterateCalculatorOptions2 != StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions.getDefaultInstance()) {
                this.stableDiffusionIterateOptions_ = StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions.newBuilder(this.stableDiffusionIterateOptions_).mergeFrom(stableDiffusionIterateCalculatorOptions).buildPartial();
            } else {
                this.stableDiffusionIterateOptions_ = stableDiffusionIterateCalculatorOptions;
            }
            this.bitField0_ |= 2;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearStableDiffusionIterateOptions() {
            this.stableDiffusionIterateOptions_ = null;
            this.bitField0_ &= -3;
        }

        public static ImageGeneratorGraphOptions parseFrom(ByteBuffer byteBuffer) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static ImageGeneratorGraphOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static ImageGeneratorGraphOptions parseFrom(ByteString byteString) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static ImageGeneratorGraphOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static ImageGeneratorGraphOptions parseFrom(byte[] bArr) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static ImageGeneratorGraphOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static ImageGeneratorGraphOptions parseFrom(InputStream inputStream) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ImageGeneratorGraphOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ImageGeneratorGraphOptions parseDelimitedFrom(InputStream inputStream) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static ImageGeneratorGraphOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static ImageGeneratorGraphOptions parseFrom(CodedInputStream codedInputStream) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static ImageGeneratorGraphOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (ImageGeneratorGraphOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(ImageGeneratorGraphOptions imageGeneratorGraphOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(imageGeneratorGraphOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<ImageGeneratorGraphOptions, Builder> implements ImageGeneratorGraphOptionsOrBuilder {
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
                super(ImageGeneratorGraphOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public String getText2ImageModelDirectory() {
                return ((ImageGeneratorGraphOptions) this.instance).getText2ImageModelDirectory();
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public ByteString getText2ImageModelDirectoryBytes() {
                return ((ImageGeneratorGraphOptions) this.instance).getText2ImageModelDirectoryBytes();
            }

            public Builder setText2ImageModelDirectory(String str) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setText2ImageModelDirectory(str);
                return this;
            }

            public Builder clearText2ImageModelDirectory() {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).clearText2ImageModelDirectory();
                return this;
            }

            public Builder setText2ImageModelDirectoryBytes(ByteString byteString) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setText2ImageModelDirectoryBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public boolean hasLoraWeightsFile() {
                return ((ImageGeneratorGraphOptions) this.instance).hasLoraWeightsFile();
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public ExternalFileProto.ExternalFile getLoraWeightsFile() {
                return ((ImageGeneratorGraphOptions) this.instance).getLoraWeightsFile();
            }

            public Builder setLoraWeightsFile(ExternalFileProto.ExternalFile externalFile) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setLoraWeightsFile(externalFile);
                return this;
            }

            public Builder setLoraWeightsFile(ExternalFileProto.ExternalFile.Builder builder) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setLoraWeightsFile(builder.build());
                return this;
            }

            public Builder mergeLoraWeightsFile(ExternalFileProto.ExternalFile externalFile) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).mergeLoraWeightsFile(externalFile);
                return this;
            }

            public Builder clearLoraWeightsFile() {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).clearLoraWeightsFile();
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public List<ControlPluginGraphOptionsProto.ControlPluginGraphOptions> getControlPluginGraphsOptionsList() {
                return Collections.unmodifiableList(((ImageGeneratorGraphOptions) this.instance).getControlPluginGraphsOptionsList());
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public int getControlPluginGraphsOptionsCount() {
                return ((ImageGeneratorGraphOptions) this.instance).getControlPluginGraphsOptionsCount();
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public ControlPluginGraphOptionsProto.ControlPluginGraphOptions getControlPluginGraphsOptions(int i) {
                return ((ImageGeneratorGraphOptions) this.instance).getControlPluginGraphsOptions(i);
            }

            public Builder setControlPluginGraphsOptions(int i, ControlPluginGraphOptionsProto.ControlPluginGraphOptions controlPluginGraphOptions) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setControlPluginGraphsOptions(i, controlPluginGraphOptions);
                return this;
            }

            public Builder setControlPluginGraphsOptions(int i, ControlPluginGraphOptionsProto.ControlPluginGraphOptions.Builder builder) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setControlPluginGraphsOptions(i, builder.build());
                return this;
            }

            public Builder addControlPluginGraphsOptions(ControlPluginGraphOptionsProto.ControlPluginGraphOptions controlPluginGraphOptions) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).addControlPluginGraphsOptions(controlPluginGraphOptions);
                return this;
            }

            public Builder addControlPluginGraphsOptions(int i, ControlPluginGraphOptionsProto.ControlPluginGraphOptions controlPluginGraphOptions) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).addControlPluginGraphsOptions(i, controlPluginGraphOptions);
                return this;
            }

            public Builder addControlPluginGraphsOptions(ControlPluginGraphOptionsProto.ControlPluginGraphOptions.Builder builder) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).addControlPluginGraphsOptions(builder.build());
                return this;
            }

            public Builder addControlPluginGraphsOptions(int i, ControlPluginGraphOptionsProto.ControlPluginGraphOptions.Builder builder) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).addControlPluginGraphsOptions(i, builder.build());
                return this;
            }

            public Builder addAllControlPluginGraphsOptions(Iterable<? extends ControlPluginGraphOptionsProto.ControlPluginGraphOptions> iterable) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).addAllControlPluginGraphsOptions(iterable);
                return this;
            }

            public Builder clearControlPluginGraphsOptions() {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).clearControlPluginGraphsOptions();
                return this;
            }

            public Builder removeControlPluginGraphsOptions(int i) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).removeControlPluginGraphsOptions(i);
                return this;
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public boolean hasStableDiffusionIterateOptions() {
                return ((ImageGeneratorGraphOptions) this.instance).hasStableDiffusionIterateOptions();
            }

            @Override // com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto.ImageGeneratorGraphOptionsOrBuilder
            public StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions getStableDiffusionIterateOptions() {
                return ((ImageGeneratorGraphOptions) this.instance).getStableDiffusionIterateOptions();
            }

            public Builder setStableDiffusionIterateOptions(StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setStableDiffusionIterateOptions(stableDiffusionIterateCalculatorOptions);
                return this;
            }

            public Builder setStableDiffusionIterateOptions(StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions.Builder builder) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).setStableDiffusionIterateOptions(builder.build());
                return this;
            }

            public Builder mergeStableDiffusionIterateOptions(StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions) {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).mergeStableDiffusionIterateOptions(stableDiffusionIterateCalculatorOptions);
                return this;
            }

            public Builder clearStableDiffusionIterateOptions() {
                copyOnWrite();
                ((ImageGeneratorGraphOptions) this.instance).clearStableDiffusionIterateOptions();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new ImageGeneratorGraphOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0000\u0004\u0000\u0001\u0001\u0004\u0004\u0000\u0001\u0000\u0001Ȉ\u0002ဉ\u0000\u0003\u001b\u0004ဉ\u0001", new Object[]{"bitField0_", "text2ImageModelDirectory_", "loraWeightsFile_", "controlPluginGraphsOptions_", ControlPluginGraphOptionsProto.ControlPluginGraphOptions.class, "stableDiffusionIterateOptions_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<ImageGeneratorGraphOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (ImageGeneratorGraphOptions.class) {
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
            ImageGeneratorGraphOptions imageGeneratorGraphOptions = new ImageGeneratorGraphOptions();
            DEFAULT_INSTANCE = imageGeneratorGraphOptions;
            GeneratedMessageLite.registerDefaultInstance(ImageGeneratorGraphOptions.class, imageGeneratorGraphOptions);
        }

        public static ImageGeneratorGraphOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<ImageGeneratorGraphOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.tasks.vision.imagegenerator.proto.ImageGeneratorGraphOptionsProto$1, reason: invalid class name */
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
