package com.google.crypto.tink.internal;

import com.google.crypto.tink.KeyManager;
import com.google.crypto.tink.config.internal.TinkFipsUtil;
import java.security.GeneralSecurityException;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;
import java.util.logging.Logger;

/* JADX INFO: loaded from: classes2.dex */
public final class KeyManagerRegistry {
    private ConcurrentMap<String, KeyManager<?>> keyManagerMap;
    private ConcurrentMap<String, Boolean> newKeyAllowedMap;
    private static final Logger logger = Logger.getLogger(KeyManagerRegistry.class.getName());
    private static final KeyManagerRegistry GLOBAL_INSTANCE = new KeyManagerRegistry();

    public static KeyManagerRegistry globalInstance() {
        return GLOBAL_INSTANCE;
    }

    public static void resetGlobalInstanceTestOnly() {
        KeyManagerRegistry keyManagerRegistry = GLOBAL_INSTANCE;
        keyManagerRegistry.keyManagerMap = new ConcurrentHashMap();
        keyManagerRegistry.newKeyAllowedMap = new ConcurrentHashMap();
    }

    public KeyManagerRegistry(KeyManagerRegistry keyManagerRegistry) {
        this.keyManagerMap = new ConcurrentHashMap(keyManagerRegistry.keyManagerMap);
        this.newKeyAllowedMap = new ConcurrentHashMap(keyManagerRegistry.newKeyAllowedMap);
    }

    public KeyManagerRegistry() {
        this.keyManagerMap = new ConcurrentHashMap();
        this.newKeyAllowedMap = new ConcurrentHashMap();
    }

    private synchronized KeyManager<?> getKeyManagerOrThrow(String str) {
        if (!this.keyManagerMap.containsKey(str)) {
            throw new GeneralSecurityException("No key manager found for key type " + str + ", see https://developers.google.com/tink/faq/registration_errors");
        }
        return this.keyManagerMap.get(str);
    }

    private synchronized void insertKeyManager(KeyManager<?> keyManager, boolean z, boolean z2) {
        try {
            String keyType = keyManager.getKeyType();
            if (z2 && this.newKeyAllowedMap.containsKey(keyType) && !this.newKeyAllowedMap.get(keyType).booleanValue()) {
                throw new GeneralSecurityException("New keys are already disallowed for key type " + keyType);
            }
            KeyManager<?> keyManager2 = this.keyManagerMap.get(keyType);
            if (keyManager2 != null && !keyManager2.getClass().equals(keyManager.getClass())) {
                logger.warning("Attempted overwrite of a registered key manager for key type " + keyType);
                throw new GeneralSecurityException(String.format("typeUrl (%s) is already registered with %s, cannot be re-registered with %s", keyType, keyManager2.getClass().getName(), keyManager.getClass().getName()));
            }
            if (!z) {
                this.keyManagerMap.putIfAbsent(keyType, keyManager);
            } else {
                this.keyManagerMap.put(keyType, keyManager);
            }
            this.newKeyAllowedMap.put(keyType, Boolean.valueOf(z2));
        } catch (Throwable th) {
            throw th;
        }
    }

    public synchronized <P> void registerKeyManager(KeyManager<P> keyManager, boolean z) {
        registerKeyManagerWithFipsCompatibility(keyManager, TinkFipsUtil.AlgorithmFipsCompatibility.ALGORITHM_NOT_FIPS, z);
    }

    public synchronized <P> void registerKeyManagerWithFipsCompatibility(KeyManager<P> keyManager, TinkFipsUtil.AlgorithmFipsCompatibility algorithmFipsCompatibility, boolean z) {
        if (!algorithmFipsCompatibility.isCompatible()) {
            throw new GeneralSecurityException("Cannot register key manager: FIPS compatibility insufficient");
        }
        insertKeyManager(keyManager, false, z);
    }

    public boolean typeUrlExists(String str) {
        return this.keyManagerMap.containsKey(str);
    }

    public <P> KeyManager<P> getKeyManager(String str, Class<P> cls) throws GeneralSecurityException {
        KeyManager<P> keyManager = (KeyManager<P>) getKeyManagerOrThrow(str);
        if (keyManager.getPrimitiveClass().equals(cls)) {
            return keyManager;
        }
        throw new GeneralSecurityException("Primitive type " + cls.getName() + " not supported by key manager of type " + keyManager.getClass() + ", which only supports: " + keyManager.getPrimitiveClass());
    }

    public KeyManager<?> getUntypedKeyManager(String str) {
        return getKeyManagerOrThrow(str);
    }

    public boolean isNewKeyAllowed(String str) {
        return this.newKeyAllowedMap.get(str).booleanValue();
    }

    public boolean isEmpty() {
        return this.keyManagerMap.isEmpty();
    }

    public synchronized void restrictToFipsIfEmptyAndGlobalInstance() {
        if (this != globalInstance()) {
            throw new GeneralSecurityException("Only the global instance can be restricted to FIPS.");
        }
        if (TinkFipsUtil.useOnlyFips()) {
            return;
        }
        if (!isEmpty()) {
            throw new GeneralSecurityException("Could not enable FIPS mode as Registry is not empty.");
        }
        TinkFipsUtil.setFipsRestricted();
    }
}
