package com.google.crypto.tink.aead;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.Immutable;
import com.google.errorprone.annotations.RestrictedApi;
import java.security.GeneralSecurityException;
import java.util.Objects;

/* JADX INFO: loaded from: classes2.dex */
public final class LegacyKmsEnvelopeAeadParameters extends AeadParameters {
    private final AeadParameters dekParametersForNewKeys;
    private final DekParsingStrategy dekParsingStrategy;
    private final String kekUri;
    private final Variant variant;

    @Immutable
    public static final class Variant {
        private final String name;
        public static final Variant TINK = new Variant("TINK");
        public static final Variant NO_PREFIX = new Variant("NO_PREFIX");

        private Variant(String str) {
            this.name = str;
        }

        public String toString() {
            return this.name;
        }
    }

    @Immutable
    public static final class DekParsingStrategy {
        private final String name;
        public static final DekParsingStrategy ASSUME_AES_GCM = new DekParsingStrategy("ASSUME_AES_GCM");
        public static final DekParsingStrategy ASSUME_XCHACHA20POLY1305 = new DekParsingStrategy("ASSUME_XCHACHA20POLY1305");
        public static final DekParsingStrategy ASSUME_CHACHA20POLY1305 = new DekParsingStrategy("ASSUME_CHACHA20POLY1305");
        public static final DekParsingStrategy ASSUME_AES_CTR_HMAC = new DekParsingStrategy("ASSUME_AES_CTR_HMAC");
        public static final DekParsingStrategy ASSUME_AES_EAX = new DekParsingStrategy("ASSUME_AES_EAX");
        public static final DekParsingStrategy ASSUME_AES_GCM_SIV = new DekParsingStrategy("ASSUME_AES_GCM_SIV");

        private DekParsingStrategy(String str) {
            this.name = str;
        }

        public String toString() {
            return this.name;
        }
    }

    private LegacyKmsEnvelopeAeadParameters(Variant variant, String str, DekParsingStrategy dekParsingStrategy, AeadParameters aeadParameters) {
        this.variant = variant;
        this.kekUri = str;
        this.dekParsingStrategy = dekParsingStrategy;
        this.dekParametersForNewKeys = aeadParameters;
    }

    public static class Builder {
        private AeadParameters dekParametersForNewKeys;
        private DekParsingStrategy dekParsingStrategy;
        private String kekUri;
        private Variant variant;

        private Builder() {
        }

        @CanIgnoreReturnValue
        public Builder setVariant(Variant variant) {
            this.variant = variant;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setKekUri(String str) {
            this.kekUri = str;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setDekParsingStrategy(DekParsingStrategy dekParsingStrategy) {
            this.dekParsingStrategy = dekParsingStrategy;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder setDekParametersForNewKeys(AeadParameters aeadParameters) {
            this.dekParametersForNewKeys = aeadParameters;
            return this;
        }

        private static boolean parsingStrategyAllowed(DekParsingStrategy dekParsingStrategy, AeadParameters aeadParameters) {
            if (dekParsingStrategy.equals(DekParsingStrategy.ASSUME_AES_GCM) && (aeadParameters instanceof AesGcmParameters)) {
                return true;
            }
            if (dekParsingStrategy.equals(DekParsingStrategy.ASSUME_CHACHA20POLY1305) && (aeadParameters instanceof ChaCha20Poly1305Parameters)) {
                return true;
            }
            if (dekParsingStrategy.equals(DekParsingStrategy.ASSUME_XCHACHA20POLY1305) && (aeadParameters instanceof XChaCha20Poly1305Parameters)) {
                return true;
            }
            if (dekParsingStrategy.equals(DekParsingStrategy.ASSUME_AES_CTR_HMAC) && (aeadParameters instanceof AesCtrHmacAeadParameters)) {
                return true;
            }
            if (dekParsingStrategy.equals(DekParsingStrategy.ASSUME_AES_EAX) && (aeadParameters instanceof AesEaxParameters)) {
                return true;
            }
            return dekParsingStrategy.equals(DekParsingStrategy.ASSUME_AES_GCM_SIV) && (aeadParameters instanceof AesGcmSivParameters);
        }

        public LegacyKmsEnvelopeAeadParameters build() throws GeneralSecurityException {
            if (this.variant == null) {
                this.variant = Variant.NO_PREFIX;
            }
            if (this.kekUri == null) {
                throw new GeneralSecurityException("kekUri must be set");
            }
            if (this.dekParsingStrategy == null) {
                throw new GeneralSecurityException("dekParsingStrategy must be set");
            }
            AeadParameters aeadParameters = this.dekParametersForNewKeys;
            if (aeadParameters == null) {
                throw new GeneralSecurityException("dekParametersForNewKeys must be set");
            }
            if (aeadParameters.hasIdRequirement()) {
                throw new GeneralSecurityException("dekParametersForNewKeys must not have ID Requirements");
            }
            if (!parsingStrategyAllowed(this.dekParsingStrategy, this.dekParametersForNewKeys)) {
                throw new GeneralSecurityException("Cannot use parsing strategy " + this.dekParsingStrategy.toString() + " when new keys are picked according to " + this.dekParametersForNewKeys + ".");
            }
            return new LegacyKmsEnvelopeAeadParameters(this.variant, this.kekUri, this.dekParsingStrategy, this.dekParametersForNewKeys);
        }
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static Builder builder() {
        return new Builder();
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public String getKekUri() {
        return this.kekUri;
    }

    public Variant getVariant() {
        return this.variant;
    }

    @Override // com.google.crypto.tink.Parameters
    public boolean hasIdRequirement() {
        return this.variant != Variant.NO_PREFIX;
    }

    public DekParsingStrategy getDekParsingStrategy() {
        return this.dekParsingStrategy;
    }

    public AeadParameters getDekParametersForNewKeys() {
        return this.dekParametersForNewKeys;
    }

    public boolean equals(Object obj) {
        if (!(obj instanceof LegacyKmsEnvelopeAeadParameters)) {
            return false;
        }
        LegacyKmsEnvelopeAeadParameters legacyKmsEnvelopeAeadParameters = (LegacyKmsEnvelopeAeadParameters) obj;
        return legacyKmsEnvelopeAeadParameters.dekParsingStrategy.equals(this.dekParsingStrategy) && legacyKmsEnvelopeAeadParameters.dekParametersForNewKeys.equals(this.dekParametersForNewKeys) && legacyKmsEnvelopeAeadParameters.kekUri.equals(this.kekUri) && legacyKmsEnvelopeAeadParameters.variant.equals(this.variant);
    }

    public int hashCode() {
        return Objects.hash(LegacyKmsEnvelopeAeadParameters.class, this.kekUri, this.dekParsingStrategy, this.dekParametersForNewKeys, this.variant);
    }

    public String toString() {
        return "LegacyKmsEnvelopeAead Parameters (kekUri: " + this.kekUri + ", dekParsingStrategy: " + this.dekParsingStrategy + ", dekParametersForNewKeys: " + this.dekParametersForNewKeys + ", variant: " + this.variant + ")";
    }
}
