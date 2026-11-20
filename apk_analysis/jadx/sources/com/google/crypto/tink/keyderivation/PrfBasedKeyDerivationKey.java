package com.google.crypto.tink.keyderivation;

import com.google.crypto.tink.AccessesPartialKey;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.prf.PrfKey;
import com.google.errorprone.annotations.RestrictedApi;
import java.security.GeneralSecurityException;
import java.util.Objects;

/* JADX INFO: loaded from: classes2.dex */
public final class PrfBasedKeyDerivationKey extends KeyDerivationKey {
    private final Integer idRequirementOrNull;
    private final PrfBasedKeyDerivationParameters parameters;
    private final PrfKey prfKey;

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public static PrfBasedKeyDerivationKey create(PrfBasedKeyDerivationParameters prfBasedKeyDerivationParameters, PrfKey prfKey, Integer num) throws GeneralSecurityException {
        if (!prfBasedKeyDerivationParameters.getPrfParameters().equals(prfKey.getParameters())) {
            throw new GeneralSecurityException("PrfParameters of passed in PrfBasedKeyDerivationParameters and passed in prfKey parameters object must match. DerivationParameters gave: " + prfBasedKeyDerivationParameters.getPrfParameters() + ", key gives: " + prfKey.getParameters());
        }
        if (prfBasedKeyDerivationParameters.getDerivedKeyParameters().hasIdRequirement() && num == null) {
            throw new GeneralSecurityException("Derived key has an ID requirement, but no idRequirement was passed in on creation of this key");
        }
        if (!prfBasedKeyDerivationParameters.getDerivedKeyParameters().hasIdRequirement() && num != null) {
            throw new GeneralSecurityException("Derived key has no ID requirement, but idRequirement was passed in on creation of this key");
        }
        return new PrfBasedKeyDerivationKey(prfBasedKeyDerivationParameters, prfKey, num);
    }

    private PrfBasedKeyDerivationKey(PrfBasedKeyDerivationParameters prfBasedKeyDerivationParameters, PrfKey prfKey, Integer num) {
        this.parameters = prfBasedKeyDerivationParameters;
        this.prfKey = prfKey;
        this.idRequirementOrNull = num;
    }

    @RestrictedApi(allowedOnPath = ".*Test\\.java", allowlistAnnotations = {AccessesPartialKey.class}, explanation = "Accessing parts of keys can produce unexpected incompatibilities, annotate the function with @AccessesPartialKey", link = "https://developers.google.com/tink/design/access_control#accessing_partial_keys")
    public PrfKey getPrfKey() {
        return this.prfKey;
    }

    @Override // com.google.crypto.tink.keyderivation.KeyDerivationKey, com.google.crypto.tink.Key
    public PrfBasedKeyDerivationParameters getParameters() {
        return this.parameters;
    }

    @Override // com.google.crypto.tink.Key
    public Integer getIdRequirementOrNull() {
        return this.idRequirementOrNull;
    }

    @Override // com.google.crypto.tink.Key
    public boolean equalsKey(Key key) {
        if (!(key instanceof PrfBasedKeyDerivationKey)) {
            return false;
        }
        PrfBasedKeyDerivationKey prfBasedKeyDerivationKey = (PrfBasedKeyDerivationKey) key;
        return prfBasedKeyDerivationKey.getParameters().equals(getParameters()) && prfBasedKeyDerivationKey.prfKey.equalsKey(this.prfKey) && Objects.equals(prfBasedKeyDerivationKey.idRequirementOrNull, this.idRequirementOrNull);
    }
}
