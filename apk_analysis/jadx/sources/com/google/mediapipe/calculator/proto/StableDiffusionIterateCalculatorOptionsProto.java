package com.google.mediapipe.calculator.proto;

import com.google.mediapipe.proto.CalculatorOptionsProto;
import com.google.protobuf.AbstractMessageLite;
import com.google.protobuf.ByteString;
import com.google.protobuf.CodedInputStream;
import com.google.protobuf.ExtensionRegistryLite;
import com.google.protobuf.GeneratedMessageLite;
import com.google.protobuf.Internal;
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
public final class StableDiffusionIterateCalculatorOptionsProto {

    public interface StableDiffusionIterateCalculatorOptionsOrBuilder extends MessageLiteOrBuilder {
        boolean containsLoraWeightsLayerMapping(String str);

        int getBaseSeed();

        StableDiffusionIterateCalculatorOptions.ClPriorityHint getClPriorityHint();

        boolean getEmitEmptyPacket();

        String getFileFolder();

        ByteString getFileFolderBytes();

        String getLoraFileFolder();

        ByteString getLoraFileFolderBytes();

        int getLoraRank();

        @Deprecated
        Map<String, Long> getLoraWeightsLayerMapping();

        int getLoraWeightsLayerMappingCount();

        Map<String, Long> getLoraWeightsLayerMappingMap();

        long getLoraWeightsLayerMappingOrDefault(String str, long j);

        long getLoraWeightsLayerMappingOrThrow(String str);

        StableDiffusionIterateCalculatorOptions.ModelType getModelType();

        int getOutputImageHeight();

        int getOutputImageWidth();

        float getPluginsStrength();

        int getShowEveryNIteration();

        boolean hasBaseSeed();

        boolean hasClPriorityHint();

        boolean hasEmitEmptyPacket();

        boolean hasFileFolder();

        boolean hasLoraFileFolder();

        boolean hasLoraRank();

        boolean hasModelType();

        boolean hasOutputImageHeight();

        boolean hasOutputImageWidth();

        boolean hasPluginsStrength();

        boolean hasShowEveryNIteration();
    }

    private StableDiffusionIterateCalculatorOptionsProto() {
    }

    public static void registerAllExtensions(ExtensionRegistryLite extensionRegistryLite) {
        extensionRegistryLite.add((GeneratedMessageLite.GeneratedExtension<?, ?>) StableDiffusionIterateCalculatorOptions.ext);
    }

    public static final class StableDiffusionIterateCalculatorOptions extends GeneratedMessageLite<StableDiffusionIterateCalculatorOptions, Builder> implements StableDiffusionIterateCalculatorOptionsOrBuilder {
        public static final int BASE_SEED_FIELD_NUMBER = 1;
        public static final int CL_PRIORITY_HINT_FIELD_NUMBER = 7;
        private static final StableDiffusionIterateCalculatorOptions DEFAULT_INSTANCE;
        public static final int EMIT_EMPTY_PACKET_FIELD_NUMBER = 6;
        public static final int EXT_FIELD_NUMBER = 510855836;
        public static final int FILE_FOLDER_FIELD_NUMBER = 4;
        public static final int LORA_FILE_FOLDER_FIELD_NUMBER = 9;
        public static final int LORA_RANK_FIELD_NUMBER = 12;
        public static final int LORA_WEIGHTS_LAYER_MAPPING_FIELD_NUMBER = 10;
        public static final int MODEL_TYPE_FIELD_NUMBER = 8;
        public static final int OUTPUT_IMAGE_HEIGHT_FIELD_NUMBER = 3;
        public static final int OUTPUT_IMAGE_WIDTH_FIELD_NUMBER = 2;
        private static volatile Parser<StableDiffusionIterateCalculatorOptions> PARSER = null;
        public static final int PLUGINS_STRENGTH_FIELD_NUMBER = 11;
        public static final int SHOW_EVERY_N_ITERATION_FIELD_NUMBER = 5;
        public static final GeneratedMessageLite.GeneratedExtension<CalculatorOptionsProto.CalculatorOptions, StableDiffusionIterateCalculatorOptions> ext;
        private int baseSeed_;
        private int bitField0_;
        private int clPriorityHint_;
        private boolean emitEmptyPacket_;
        private MapFieldLite<String, Long> loraWeightsLayerMapping_ = MapFieldLite.emptyMapField();
        private int outputImageWidth_ = 512;
        private int outputImageHeight_ = 512;
        private String fileFolder_ = "bins/";
        private String loraFileFolder_ = "";
        private int loraRank_ = 4;
        private int showEveryNIteration_ = 1;
        private int modelType_ = 1;
        private float pluginsStrength_ = 1.0f;

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

        private StableDiffusionIterateCalculatorOptions() {
        }

        public enum ClPriorityHint implements Internal.EnumLite {
            PRIORITY_HINT_NORMAL(0),
            PRIORITY_HINT_LOW(1),
            PRIORITY_HINT_HIGH(2);

            public static final int PRIORITY_HINT_HIGH_VALUE = 2;
            public static final int PRIORITY_HINT_LOW_VALUE = 1;
            public static final int PRIORITY_HINT_NORMAL_VALUE = 0;
            private static final Internal.EnumLiteMap<ClPriorityHint> internalValueMap = new Internal.EnumLiteMap<ClPriorityHint>() { // from class: com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions.ClPriorityHint.1
                @Override // com.google.protobuf.Internal.EnumLiteMap
                public ClPriorityHint findValueByNumber(int i) {
                    return ClPriorityHint.forNumber(i);
                }
            };
            private final int value;

            @Override // com.google.protobuf.Internal.EnumLite
            public final int getNumber() {
                return this.value;
            }

            @Deprecated
            public static ClPriorityHint valueOf(int i) {
                return forNumber(i);
            }

            public static ClPriorityHint forNumber(int i) {
                if (i == 0) {
                    return PRIORITY_HINT_NORMAL;
                }
                if (i == 1) {
                    return PRIORITY_HINT_LOW;
                }
                if (i != 2) {
                    return null;
                }
                return PRIORITY_HINT_HIGH;
            }

            public static Internal.EnumLiteMap<ClPriorityHint> internalGetValueMap() {
                return internalValueMap;
            }

            public static Internal.EnumVerifier internalGetVerifier() {
                return ClPriorityHintVerifier.INSTANCE;
            }

            private static final class ClPriorityHintVerifier implements Internal.EnumVerifier {
                static final Internal.EnumVerifier INSTANCE = new ClPriorityHintVerifier();

                private ClPriorityHintVerifier() {
                }

                @Override // com.google.protobuf.Internal.EnumVerifier
                public boolean isInRange(int i) {
                    return ClPriorityHint.forNumber(i) != null;
                }
            }

            ClPriorityHint(int i) {
                this.value = i;
            }
        }

        public enum ModelType implements Internal.EnumLite {
            DEFAULT(0),
            SD_1(1);

            public static final int DEFAULT_VALUE = 0;
            public static final int SD_1_VALUE = 1;
            private static final Internal.EnumLiteMap<ModelType> internalValueMap = new Internal.EnumLiteMap<ModelType>() { // from class: com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptions.ModelType.1
                @Override // com.google.protobuf.Internal.EnumLiteMap
                public ModelType findValueByNumber(int i) {
                    return ModelType.forNumber(i);
                }
            };
            private final int value;

            @Override // com.google.protobuf.Internal.EnumLite
            public final int getNumber() {
                return this.value;
            }

            @Deprecated
            public static ModelType valueOf(int i) {
                return forNumber(i);
            }

            public static ModelType forNumber(int i) {
                if (i == 0) {
                    return DEFAULT;
                }
                if (i != 1) {
                    return null;
                }
                return SD_1;
            }

            public static Internal.EnumLiteMap<ModelType> internalGetValueMap() {
                return internalValueMap;
            }

            public static Internal.EnumVerifier internalGetVerifier() {
                return ModelTypeVerifier.INSTANCE;
            }

            private static final class ModelTypeVerifier implements Internal.EnumVerifier {
                static final Internal.EnumVerifier INSTANCE = new ModelTypeVerifier();

                private ModelTypeVerifier() {
                }

                @Override // com.google.protobuf.Internal.EnumVerifier
                public boolean isInRange(int i) {
                    return ModelType.forNumber(i) != null;
                }
            }

            ModelType(int i) {
                this.value = i;
            }
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasBaseSeed() {
            return (this.bitField0_ & 1) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public int getBaseSeed() {
            return this.baseSeed_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setBaseSeed(int i) {
            this.bitField0_ |= 1;
            this.baseSeed_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearBaseSeed() {
            this.bitField0_ &= -2;
            this.baseSeed_ = 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasOutputImageWidth() {
            return (this.bitField0_ & 2) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public int getOutputImageWidth() {
            return this.outputImageWidth_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputImageWidth(int i) {
            this.bitField0_ |= 2;
            this.outputImageWidth_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOutputImageWidth() {
            this.bitField0_ &= -3;
            this.outputImageWidth_ = 512;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasOutputImageHeight() {
            return (this.bitField0_ & 4) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public int getOutputImageHeight() {
            return this.outputImageHeight_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setOutputImageHeight(int i) {
            this.bitField0_ |= 4;
            this.outputImageHeight_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearOutputImageHeight() {
            this.bitField0_ &= -5;
            this.outputImageHeight_ = 512;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasFileFolder() {
            return (this.bitField0_ & 8) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public String getFileFolder() {
            return this.fileFolder_;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public ByteString getFileFolderBytes() {
            return ByteString.copyFromUtf8(this.fileFolder_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileFolder(String str) {
            str.getClass();
            this.bitField0_ |= 8;
            this.fileFolder_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearFileFolder() {
            this.bitField0_ &= -9;
            this.fileFolder_ = getDefaultInstance().getFileFolder();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setFileFolderBytes(ByteString byteString) {
            this.fileFolder_ = byteString.toStringUtf8();
            this.bitField0_ |= 8;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasLoraFileFolder() {
            return (this.bitField0_ & 16) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public String getLoraFileFolder() {
            return this.loraFileFolder_;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public ByteString getLoraFileFolderBytes() {
            return ByteString.copyFromUtf8(this.loraFileFolder_);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLoraFileFolder(String str) {
            str.getClass();
            this.bitField0_ |= 16;
            this.loraFileFolder_ = str;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLoraFileFolder() {
            this.bitField0_ &= -17;
            this.loraFileFolder_ = getDefaultInstance().getLoraFileFolder();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLoraFileFolderBytes(ByteString byteString) {
            this.loraFileFolder_ = byteString.toStringUtf8();
            this.bitField0_ |= 16;
        }

        private static final class LoraWeightsLayerMappingDefaultEntryHolder {
            static final MapEntryLite<String, Long> defaultEntry = MapEntryLite.newDefaultInstance(WireFormat.FieldType.STRING, "", WireFormat.FieldType.UINT64, 0L);

            private LoraWeightsLayerMappingDefaultEntryHolder() {
            }
        }

        private MapFieldLite<String, Long> internalGetLoraWeightsLayerMapping() {
            return this.loraWeightsLayerMapping_;
        }

        private MapFieldLite<String, Long> internalGetMutableLoraWeightsLayerMapping() {
            if (!this.loraWeightsLayerMapping_.isMutable()) {
                this.loraWeightsLayerMapping_ = this.loraWeightsLayerMapping_.mutableCopy();
            }
            return this.loraWeightsLayerMapping_;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public int getLoraWeightsLayerMappingCount() {
            return internalGetLoraWeightsLayerMapping().size();
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean containsLoraWeightsLayerMapping(String str) {
            str.getClass();
            return internalGetLoraWeightsLayerMapping().containsKey(str);
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        @Deprecated
        public Map<String, Long> getLoraWeightsLayerMapping() {
            return getLoraWeightsLayerMappingMap();
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public Map<String, Long> getLoraWeightsLayerMappingMap() {
            return Collections.unmodifiableMap(internalGetLoraWeightsLayerMapping());
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public long getLoraWeightsLayerMappingOrDefault(String str, long j) {
            str.getClass();
            MapFieldLite<String, Long> mapFieldLiteInternalGetLoraWeightsLayerMapping = internalGetLoraWeightsLayerMapping();
            return mapFieldLiteInternalGetLoraWeightsLayerMapping.containsKey(str) ? mapFieldLiteInternalGetLoraWeightsLayerMapping.get(str).longValue() : j;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public long getLoraWeightsLayerMappingOrThrow(String str) {
            str.getClass();
            MapFieldLite<String, Long> mapFieldLiteInternalGetLoraWeightsLayerMapping = internalGetLoraWeightsLayerMapping();
            if (!mapFieldLiteInternalGetLoraWeightsLayerMapping.containsKey(str)) {
                throw new IllegalArgumentException();
            }
            return mapFieldLiteInternalGetLoraWeightsLayerMapping.get(str).longValue();
        }

        /* JADX INFO: Access modifiers changed from: private */
        public Map<String, Long> getMutableLoraWeightsLayerMappingMap() {
            return internalGetMutableLoraWeightsLayerMapping();
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasLoraRank() {
            return (this.bitField0_ & 32) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public int getLoraRank() {
            return this.loraRank_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setLoraRank(int i) {
            this.bitField0_ |= 32;
            this.loraRank_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearLoraRank() {
            this.bitField0_ &= -33;
            this.loraRank_ = 4;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasShowEveryNIteration() {
            return (this.bitField0_ & 64) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public int getShowEveryNIteration() {
            return this.showEveryNIteration_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setShowEveryNIteration(int i) {
            this.bitField0_ |= 64;
            this.showEveryNIteration_ = i;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearShowEveryNIteration() {
            this.bitField0_ &= -65;
            this.showEveryNIteration_ = 1;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasEmitEmptyPacket() {
            return (this.bitField0_ & 128) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean getEmitEmptyPacket() {
            return this.emitEmptyPacket_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setEmitEmptyPacket(boolean z) {
            this.bitField0_ |= 128;
            this.emitEmptyPacket_ = z;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearEmitEmptyPacket() {
            this.bitField0_ &= -129;
            this.emitEmptyPacket_ = false;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasClPriorityHint() {
            return (this.bitField0_ & 256) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public ClPriorityHint getClPriorityHint() {
            ClPriorityHint clPriorityHintForNumber = ClPriorityHint.forNumber(this.clPriorityHint_);
            return clPriorityHintForNumber == null ? ClPriorityHint.PRIORITY_HINT_NORMAL : clPriorityHintForNumber;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setClPriorityHint(ClPriorityHint clPriorityHint) {
            this.clPriorityHint_ = clPriorityHint.getNumber();
            this.bitField0_ |= 256;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearClPriorityHint() {
            this.bitField0_ &= -257;
            this.clPriorityHint_ = 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasModelType() {
            return (this.bitField0_ & 512) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public ModelType getModelType() {
            ModelType modelTypeForNumber = ModelType.forNumber(this.modelType_);
            return modelTypeForNumber == null ? ModelType.SD_1 : modelTypeForNumber;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setModelType(ModelType modelType) {
            this.modelType_ = modelType.getNumber();
            this.bitField0_ |= 512;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearModelType() {
            this.bitField0_ &= -513;
            this.modelType_ = 1;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public boolean hasPluginsStrength() {
            return (this.bitField0_ & 1024) != 0;
        }

        @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
        public float getPluginsStrength() {
            return this.pluginsStrength_;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setPluginsStrength(float f) {
            this.bitField0_ |= 1024;
            this.pluginsStrength_ = f;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPluginsStrength() {
            this.bitField0_ &= -1025;
            this.pluginsStrength_ = 1.0f;
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(ByteBuffer byteBuffer) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(ByteBuffer byteBuffer, ExtensionRegistryLite extensionRegistryLite) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteBuffer, extensionRegistryLite);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(ByteString byteString) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(ByteString byteString, ExtensionRegistryLite extensionRegistryLite) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, byteString, extensionRegistryLite);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(byte[] bArr) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(byte[] bArr, ExtensionRegistryLite extensionRegistryLite) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, bArr, extensionRegistryLite);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(InputStream inputStream) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static StableDiffusionIterateCalculatorOptions parseDelimitedFrom(InputStream inputStream) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream);
        }

        public static StableDiffusionIterateCalculatorOptions parseDelimitedFrom(InputStream inputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseDelimitedFrom(DEFAULT_INSTANCE, inputStream, extensionRegistryLite);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(CodedInputStream codedInputStream) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream);
        }

        public static StableDiffusionIterateCalculatorOptions parseFrom(CodedInputStream codedInputStream, ExtensionRegistryLite extensionRegistryLite) {
            return (StableDiffusionIterateCalculatorOptions) GeneratedMessageLite.parseFrom(DEFAULT_INSTANCE, codedInputStream, extensionRegistryLite);
        }

        public static Builder newBuilder() {
            return (Builder) DEFAULT_INSTANCE.createBuilder();
        }

        public static Builder newBuilder(StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions) {
            return (Builder) DEFAULT_INSTANCE.createBuilder(stableDiffusionIterateCalculatorOptions);
        }

        public static final class Builder extends GeneratedMessageLite.Builder<StableDiffusionIterateCalculatorOptions, Builder> implements StableDiffusionIterateCalculatorOptionsOrBuilder {
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
                super(StableDiffusionIterateCalculatorOptions.DEFAULT_INSTANCE);
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasBaseSeed() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasBaseSeed();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public int getBaseSeed() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getBaseSeed();
            }

            public Builder setBaseSeed(int i) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setBaseSeed(i);
                return this;
            }

            public Builder clearBaseSeed() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearBaseSeed();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasOutputImageWidth() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasOutputImageWidth();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public int getOutputImageWidth() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getOutputImageWidth();
            }

            public Builder setOutputImageWidth(int i) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setOutputImageWidth(i);
                return this;
            }

            public Builder clearOutputImageWidth() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearOutputImageWidth();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasOutputImageHeight() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasOutputImageHeight();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public int getOutputImageHeight() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getOutputImageHeight();
            }

            public Builder setOutputImageHeight(int i) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setOutputImageHeight(i);
                return this;
            }

            public Builder clearOutputImageHeight() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearOutputImageHeight();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasFileFolder() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasFileFolder();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public String getFileFolder() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getFileFolder();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public ByteString getFileFolderBytes() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getFileFolderBytes();
            }

            public Builder setFileFolder(String str) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setFileFolder(str);
                return this;
            }

            public Builder clearFileFolder() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearFileFolder();
                return this;
            }

            public Builder setFileFolderBytes(ByteString byteString) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setFileFolderBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasLoraFileFolder() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasLoraFileFolder();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public String getLoraFileFolder() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getLoraFileFolder();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public ByteString getLoraFileFolderBytes() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getLoraFileFolderBytes();
            }

            public Builder setLoraFileFolder(String str) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setLoraFileFolder(str);
                return this;
            }

            public Builder clearLoraFileFolder() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearLoraFileFolder();
                return this;
            }

            public Builder setLoraFileFolderBytes(ByteString byteString) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setLoraFileFolderBytes(byteString);
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public int getLoraWeightsLayerMappingCount() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getLoraWeightsLayerMappingMap().size();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean containsLoraWeightsLayerMapping(String str) {
                str.getClass();
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getLoraWeightsLayerMappingMap().containsKey(str);
            }

            public Builder clearLoraWeightsLayerMapping() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).getMutableLoraWeightsLayerMappingMap().clear();
                return this;
            }

            public Builder removeLoraWeightsLayerMapping(String str) {
                str.getClass();
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).getMutableLoraWeightsLayerMappingMap().remove(str);
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            @Deprecated
            public Map<String, Long> getLoraWeightsLayerMapping() {
                return getLoraWeightsLayerMappingMap();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public Map<String, Long> getLoraWeightsLayerMappingMap() {
                return Collections.unmodifiableMap(((StableDiffusionIterateCalculatorOptions) this.instance).getLoraWeightsLayerMappingMap());
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public long getLoraWeightsLayerMappingOrDefault(String str, long j) {
                str.getClass();
                Map<String, Long> loraWeightsLayerMappingMap = ((StableDiffusionIterateCalculatorOptions) this.instance).getLoraWeightsLayerMappingMap();
                return loraWeightsLayerMappingMap.containsKey(str) ? loraWeightsLayerMappingMap.get(str).longValue() : j;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public long getLoraWeightsLayerMappingOrThrow(String str) {
                str.getClass();
                Map<String, Long> loraWeightsLayerMappingMap = ((StableDiffusionIterateCalculatorOptions) this.instance).getLoraWeightsLayerMappingMap();
                if (!loraWeightsLayerMappingMap.containsKey(str)) {
                    throw new IllegalArgumentException();
                }
                return loraWeightsLayerMappingMap.get(str).longValue();
            }

            public Builder putLoraWeightsLayerMapping(String str, long j) {
                str.getClass();
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).getMutableLoraWeightsLayerMappingMap().put(str, Long.valueOf(j));
                return this;
            }

            public Builder putAllLoraWeightsLayerMapping(Map<String, Long> map) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).getMutableLoraWeightsLayerMappingMap().putAll(map);
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasLoraRank() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasLoraRank();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public int getLoraRank() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getLoraRank();
            }

            public Builder setLoraRank(int i) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setLoraRank(i);
                return this;
            }

            public Builder clearLoraRank() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearLoraRank();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasShowEveryNIteration() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasShowEveryNIteration();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public int getShowEveryNIteration() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getShowEveryNIteration();
            }

            public Builder setShowEveryNIteration(int i) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setShowEveryNIteration(i);
                return this;
            }

            public Builder clearShowEveryNIteration() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearShowEveryNIteration();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasEmitEmptyPacket() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasEmitEmptyPacket();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean getEmitEmptyPacket() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getEmitEmptyPacket();
            }

            public Builder setEmitEmptyPacket(boolean z) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setEmitEmptyPacket(z);
                return this;
            }

            public Builder clearEmitEmptyPacket() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearEmitEmptyPacket();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasClPriorityHint() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasClPriorityHint();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public ClPriorityHint getClPriorityHint() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getClPriorityHint();
            }

            public Builder setClPriorityHint(ClPriorityHint clPriorityHint) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setClPriorityHint(clPriorityHint);
                return this;
            }

            public Builder clearClPriorityHint() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearClPriorityHint();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasModelType() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasModelType();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public ModelType getModelType() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getModelType();
            }

            public Builder setModelType(ModelType modelType) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setModelType(modelType);
                return this;
            }

            public Builder clearModelType() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearModelType();
                return this;
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public boolean hasPluginsStrength() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).hasPluginsStrength();
            }

            @Override // com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto.StableDiffusionIterateCalculatorOptionsOrBuilder
            public float getPluginsStrength() {
                return ((StableDiffusionIterateCalculatorOptions) this.instance).getPluginsStrength();
            }

            public Builder setPluginsStrength(float f) {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).setPluginsStrength(f);
                return this;
            }

            public Builder clearPluginsStrength() {
                copyOnWrite();
                ((StableDiffusionIterateCalculatorOptions) this.instance).clearPluginsStrength();
                return this;
            }
        }

        @Override // com.google.protobuf.GeneratedMessageLite
        protected final Object dynamicMethod(GeneratedMessageLite.MethodToInvoke methodToInvoke, Object obj, Object obj2) {
            Parser defaultInstanceBasedParser;
            AnonymousClass1 anonymousClass1 = null;
            switch (AnonymousClass1.$SwitchMap$com$google$protobuf$GeneratedMessageLite$MethodToInvoke[methodToInvoke.ordinal()]) {
                case 1:
                    return new StableDiffusionIterateCalculatorOptions();
                case 2:
                    return new Builder(anonymousClass1);
                case 3:
                    return GeneratedMessageLite.newMessageInfo(DEFAULT_INSTANCE, "\u0001\f\u0000\u0001\u0001\f\f\u0001\u0000\u0000\u0001ဋ\u0000\u0002င\u0001\u0003င\u0002\u0004ဈ\u0003\u0005င\u0006\u0006ဇ\u0007\u0007᠌\b\b᠌\t\tဈ\u0004\n2\u000bခ\n\fင\u0005", new Object[]{"bitField0_", "baseSeed_", "outputImageWidth_", "outputImageHeight_", "fileFolder_", "showEveryNIteration_", "emitEmptyPacket_", "clPriorityHint_", ClPriorityHint.internalGetVerifier(), "modelType_", ModelType.internalGetVerifier(), "loraFileFolder_", "loraWeightsLayerMapping_", LoraWeightsLayerMappingDefaultEntryHolder.defaultEntry, "pluginsStrength_", "loraRank_"});
                case 4:
                    return DEFAULT_INSTANCE;
                case 5:
                    Parser<StableDiffusionIterateCalculatorOptions> parser = PARSER;
                    if (parser != null) {
                        return parser;
                    }
                    synchronized (StableDiffusionIterateCalculatorOptions.class) {
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
            StableDiffusionIterateCalculatorOptions stableDiffusionIterateCalculatorOptions = new StableDiffusionIterateCalculatorOptions();
            DEFAULT_INSTANCE = stableDiffusionIterateCalculatorOptions;
            GeneratedMessageLite.registerDefaultInstance(StableDiffusionIterateCalculatorOptions.class, stableDiffusionIterateCalculatorOptions);
            ext = GeneratedMessageLite.newSingularGeneratedExtension(CalculatorOptionsProto.CalculatorOptions.getDefaultInstance(), getDefaultInstance(), getDefaultInstance(), null, EXT_FIELD_NUMBER, WireFormat.FieldType.MESSAGE, StableDiffusionIterateCalculatorOptions.class);
        }

        public static StableDiffusionIterateCalculatorOptions getDefaultInstance() {
            return DEFAULT_INSTANCE;
        }

        public static Parser<StableDiffusionIterateCalculatorOptions> parser() {
            return DEFAULT_INSTANCE.getParserForType();
        }
    }

    /* JADX INFO: renamed from: com.google.mediapipe.calculator.proto.StableDiffusionIterateCalculatorOptionsProto$1, reason: invalid class name */
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
