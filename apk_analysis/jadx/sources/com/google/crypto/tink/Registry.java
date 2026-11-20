package com.google.crypto.tink;

import com.google.crypto.tink.config.internal.TinkFipsUtil;
import com.google.crypto.tink.internal.KeyManagerRegistry;
import com.google.crypto.tink.internal.MutableParametersRegistry;
import com.google.crypto.tink.internal.MutablePrimitiveRegistry;
import com.google.crypto.tink.internal.PrimitiveSet;
import com.google.crypto.tink.prf.Prf;
import com.google.crypto.tink.proto.KeyData;
import com.google.crypto.tink.shaded.protobuf.ByteString;
import com.google.crypto.tink.shaded.protobuf.ExtensionRegistryLite;
import com.google.crypto.tink.shaded.protobuf.InvalidProtocolBufferException;
import com.google.crypto.tink.shaded.protobuf.MessageLite;
import java.security.GeneralSecurityException;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;
import java.util.logging.Logger;

/* JADX INFO: loaded from: classes2.dex */
public final class Registry {
    private static final Logger logger = Logger.getLogger(Registry.class.getName());
    private static final ConcurrentMap<String, Catalogue<?>> catalogueMap = new ConcurrentHashMap();
    private static final Set<Class<?>> ALLOWED_PRIMITIVES = Collections.unmodifiableSet(createAllowedPrimitives());

    static synchronized void reset() {
        KeyManagerRegistry.resetGlobalInstanceTestOnly();
        MutablePrimitiveRegistry.resetGlobalInstanceTestOnly();
        catalogueMap.clear();
    }

    @Deprecated
    public static synchronized void addCatalogue(String str, Catalogue<?> catalogue) {
        try {
            if (str == null) {
                throw new IllegalArgumentException("catalogueName must be non-null.");
            }
            if (catalogue == null) {
                throw new IllegalArgumentException("catalogue must be non-null.");
            }
            ConcurrentMap<String, Catalogue<?>> concurrentMap = catalogueMap;
            Locale locale = Locale.US;
            if (concurrentMap.containsKey(str.toLowerCase(locale))) {
                if (!catalogue.getClass().getName().equals(concurrentMap.get(str.toLowerCase(locale)).getClass().getName())) {
                    logger.warning("Attempted overwrite of a catalogueName catalogue for name " + str);
                    throw new GeneralSecurityException("catalogue for name " + str + " has been already registered");
                }
            }
            concurrentMap.put(str.toLowerCase(locale), catalogue);
        } catch (Throwable th) {
            throw th;
        }
    }

    @Deprecated
    public static Catalogue<?> getCatalogue(String str) throws GeneralSecurityException {
        if (str == null) {
            throw new IllegalArgumentException("catalogueName must be non-null.");
        }
        ConcurrentMap<String, Catalogue<?>> concurrentMap = catalogueMap;
        Locale locale = Locale.US;
        Catalogue<?> catalogue = concurrentMap.get(str.toLowerCase(locale));
        if (catalogue != null) {
            return catalogue;
        }
        String str2 = String.format("no catalogue found for %s. ", str);
        if (str.toLowerCase(locale).startsWith("tinkaead")) {
            str2 = str2 + "Maybe call AeadConfig.register().";
        }
        if (str.toLowerCase(locale).startsWith("tinkdeterministicaead")) {
            str2 = str2 + "Maybe call DeterministicAeadConfig.register().";
        } else if (str.toLowerCase(locale).startsWith("tinkstreamingaead")) {
            str2 = str2 + "Maybe call StreamingAeadConfig.register().";
        } else if (str.toLowerCase(locale).startsWith("tinkhybriddecrypt") || str.toLowerCase(locale).startsWith("tinkhybridencrypt")) {
            str2 = str2 + "Maybe call HybridConfig.register().";
        } else if (str.toLowerCase(locale).startsWith("tinkmac")) {
            str2 = str2 + "Maybe call MacConfig.register().";
        } else if (str.toLowerCase(locale).startsWith("tinkpublickeysign") || str.toLowerCase(locale).startsWith("tinkpublickeyverify")) {
            str2 = str2 + "Maybe call SignatureConfig.register().";
        } else if (str.toLowerCase(locale).startsWith("tink")) {
            str2 = str2 + "Maybe call TinkConfig.register().";
        }
        throw new GeneralSecurityException(str2);
    }

    public static synchronized <P> void registerKeyManager(KeyManager<P> keyManager) {
        registerKeyManager((KeyManager) keyManager, true);
    }

    private static Set<Class<?>> createAllowedPrimitives() {
        HashSet hashSet = new HashSet();
        hashSet.add(Aead.class);
        hashSet.add(DeterministicAead.class);
        hashSet.add(StreamingAead.class);
        hashSet.add(HybridEncrypt.class);
        hashSet.add(HybridDecrypt.class);
        hashSet.add(Mac.class);
        hashSet.add(Prf.class);
        hashSet.add(PublicKeySign.class);
        hashSet.add(PublicKeyVerify.class);
        return hashSet;
    }

    public static synchronized <P> void registerKeyManager(KeyManager<P> keyManager, boolean z) {
        try {
            if (keyManager == null) {
                throw new IllegalArgumentException("key manager must be non-null.");
            }
            if (!ALLOWED_PRIMITIVES.contains(keyManager.getPrimitiveClass())) {
                throw new GeneralSecurityException("Registration of key managers for class " + keyManager.getPrimitiveClass() + " has been disabled. Please file an issue on https://github.com/tink-crypto/tink-java");
            }
            if (!TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_NOT_FIPS.isCompatible()) {
                throw new GeneralSecurityException("Registering key managers is not supported in FIPS mode");
            }
            KeyManagerRegistry.globalInstance().registerKeyManager(keyManager, z);
        } catch (Throwable th) {
            throw th;
        }
    }

    @Deprecated
    public static synchronized <P> void registerKeyManager(String str, KeyManager<P> keyManager) {
        registerKeyManager(str, keyManager, true);
    }

    @Deprecated
    public static synchronized <P> void registerKeyManager(String str, KeyManager<P> keyManager, boolean z) {
        try {
            if (keyManager == null) {
                throw new IllegalArgumentException("key manager must be non-null.");
            }
            if (!str.equals(keyManager.getKeyType())) {
                throw new GeneralSecurityException("Manager does not support key type " + str + ".");
            }
            registerKeyManager(keyManager, z);
        } catch (Throwable th) {
            throw th;
        }
    }

    @Deprecated
    public static <P> KeyManager<P> getKeyManager(String str, Class<P> cls) {
        return KeyManagerRegistry.globalInstance().getKeyManager(str, cls);
    }

    @Deprecated
    public static KeyManager<?> getUntypedKeyManager(String str) {
        return KeyManagerRegistry.globalInstance().getUntypedKeyManager(str);
    }

    @Deprecated
    public static synchronized KeyData newKeyData(com.google.crypto.tink.proto.KeyTemplate keyTemplate) {
        KeyManager<?> untypedKeyManager;
        untypedKeyManager = KeyManagerRegistry.globalInstance().getUntypedKeyManager(keyTemplate.getTypeUrl());
        if (KeyManagerRegistry.globalInstance().isNewKeyAllowed(keyTemplate.getTypeUrl())) {
        } else {
            throw new GeneralSecurityException("newKey-operation not permitted for key type " + keyTemplate.getTypeUrl());
        }
        return untypedKeyManager.newKeyData(keyTemplate.getValue());
    }

    @Deprecated
    public static synchronized KeyData newKeyData(KeyTemplate keyTemplate) {
        try {
        } catch (InvalidProtocolBufferException e) {
            throw new GeneralSecurityException("Failed to parse serialized parameters", e);
        }
        return newKeyData(com.google.crypto.tink.proto.KeyTemplate.parseFrom(TinkProtoParametersFormat.serialize(keyTemplate.toParameters()), ExtensionRegistryLite.getEmptyRegistry()));
    }

    @Deprecated
    public static synchronized MessageLite newKey(com.google.crypto.tink.proto.KeyTemplate keyTemplate) {
        KeyManager<?> untypedKeyManager;
        untypedKeyManager = getUntypedKeyManager(keyTemplate.getTypeUrl());
        if (KeyManagerRegistry.globalInstance().isNewKeyAllowed(keyTemplate.getTypeUrl())) {
        } else {
            throw new GeneralSecurityException("newKey-operation not permitted for key type " + keyTemplate.getTypeUrl());
        }
        return untypedKeyManager.newKey(keyTemplate.getValue());
    }

    @Deprecated
    public static synchronized MessageLite newKey(String str, MessageLite messageLite) {
        KeyManager<?> untypedKeyManager;
        untypedKeyManager = getUntypedKeyManager(str);
        if (KeyManagerRegistry.globalInstance().isNewKeyAllowed(str)) {
        } else {
            throw new GeneralSecurityException("newKey-operation not permitted for key type " + str);
        }
        return untypedKeyManager.newKey(messageLite);
    }

    @Deprecated
    public static KeyData getPublicKeyData(String str, ByteString byteString) throws GeneralSecurityException {
        KeyManager<?> untypedKeyManager = getUntypedKeyManager(str);
        if (!(untypedKeyManager instanceof PrivateKeyManager)) {
            throw new GeneralSecurityException("manager for key type " + str + " is not a PrivateKeyManager");
        }
        return ((PrivateKeyManager) untypedKeyManager).getPublicKeyData(byteString);
    }

    @Deprecated
    public static <P> P getPrimitive(String str, MessageLite messageLite, Class<P> cls) {
        return KeyManagerRegistry.globalInstance().getKeyManager(str, cls).getPrimitive(messageLite.toByteString());
    }

    public static <P> P getPrimitive(String str, ByteString byteString, Class<P> cls) {
        return KeyManagerRegistry.globalInstance().getKeyManager(str, cls).getPrimitive(byteString);
    }

    public static <P> P getPrimitive(String str, byte[] bArr, Class<P> cls) {
        return (P) getPrimitive(str, ByteString.copyFrom(bArr), cls);
    }

    public static <P> P getPrimitive(KeyData keyData, Class<P> cls) {
        return (P) getPrimitive(keyData.getTypeUrl(), keyData.getValue(), cls);
    }

    static <KeyT extends Key, P> P getFullPrimitive(KeyT keyt, Class<P> cls) {
        return (P) MutablePrimitiveRegistry.globalInstance().getPrimitive(keyt, cls);
    }

    public static <B, P> P wrap(PrimitiveSet<B> primitiveSet, Class<P> cls) {
        return (P) MutablePrimitiveRegistry.globalInstance().wrap(primitiveSet, cls);
    }

    public static <P> P wrap(PrimitiveSet<P> primitiveSet) {
        return (P) wrap(primitiveSet, primitiveSet.getPrimitiveClass());
    }

    public static synchronized List<String> keyTemplates() {
        return MutableParametersRegistry.globalInstance().getNames();
    }

    public static Class<?> getInputPrimitive(Class<?> cls) {
        try {
            return MutablePrimitiveRegistry.globalInstance().getInputPrimitiveClass(cls);
        } catch (GeneralSecurityException unused) {
            return null;
        }
    }

    public static synchronized void restrictToFipsIfEmpty() {
        KeyManagerRegistry.globalInstance().restrictToFipsIfEmptyAndGlobalInstance();
    }

    private Registry() {
    }
}
