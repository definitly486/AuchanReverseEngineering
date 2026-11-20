package com.google.crypto.tink;

import com.google.crypto.tink.annotations.Alpha;
import com.google.crypto.tink.internal.InternalConfiguration;
import com.google.crypto.tink.internal.KeysetHandleInterface;
import com.google.crypto.tink.internal.MonitoringAnnotations;
import com.google.crypto.tink.internal.MutableKeyCreationRegistry;
import com.google.crypto.tink.internal.MutableParametersRegistry;
import com.google.crypto.tink.internal.MutableSerializationRegistry;
import com.google.crypto.tink.internal.PrimitiveConstructor;
import com.google.crypto.tink.internal.PrimitiveSet;
import com.google.crypto.tink.internal.ProtoKeySerialization;
import com.google.crypto.tink.proto.EncryptedKeyset;
import com.google.crypto.tink.proto.KeyData;
import com.google.crypto.tink.proto.KeyStatusType;
import com.google.crypto.tink.proto.Keyset;
import com.google.crypto.tink.proto.KeysetInfo;
import com.google.crypto.tink.proto.OutputPrefixType;
import com.google.crypto.tink.shaded.protobuf.ByteString;
import com.google.crypto.tink.shaded.protobuf.ExtensionRegistryLite;
import com.google.crypto.tink.shaded.protobuf.InvalidProtocolBufferException;
import com.google.crypto.tink.tinkkey.KeyAccess;
import com.google.crypto.tink.tinkkey.KeyHandle;
import com.google.crypto.tink.tinkkey.internal.InternalKeyHandle;
import com.google.crypto.tink.tinkkey.internal.ProtoKey;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.Immutable;
import com.google.errorprone.annotations.InlineMe;
import java.security.GeneralSecurityException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
public final class KeysetHandle implements KeysetHandleInterface {
    private final MonitoringAnnotations annotations;
    private final List<Entry> entries;
    private final Keyset keyset;

    /* synthetic */ KeysetHandle(Keyset keyset, List list, MonitoringAnnotations monitoringAnnotations, AnonymousClass1 anonymousClass1) {
        this(keyset, list, monitoringAnnotations);
    }

    public static final class Builder {
        private final List<Entry> entries = new ArrayList();
        private GeneralSecurityException errorToThrow = null;
        private MonitoringAnnotations annotations = MonitoringAnnotations.EMPTY;
        private boolean buildCalled = false;

        private static class KeyIdStrategy {
            private static final KeyIdStrategy RANDOM_ID = new KeyIdStrategy();
            private final int fixedId;

            private KeyIdStrategy() {
                this.fixedId = 0;
            }

            private KeyIdStrategy(int i) {
                this.fixedId = i;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public static KeyIdStrategy randomId() {
                return RANDOM_ID;
            }

            /* JADX INFO: Access modifiers changed from: private */
            public static KeyIdStrategy fixedId(int i) {
                return new KeyIdStrategy(i);
            }

            /* JADX INFO: Access modifiers changed from: private */
            public int getFixedId() {
                return this.fixedId;
            }
        }

        public static final class Entry {
            private Builder builder;
            private boolean isPrimary;
            private final Key key;
            private KeyStatus keyStatus;
            private final Parameters parameters;
            private KeyIdStrategy strategy;

            /* synthetic */ Entry(Key key, AnonymousClass1 anonymousClass1) {
                this(key);
            }

            /* synthetic */ Entry(Parameters parameters, AnonymousClass1 anonymousClass1) {
                this(parameters);
            }

            private Entry(Key key) {
                this.keyStatus = KeyStatus.ENABLED;
                this.strategy = null;
                this.builder = null;
                this.key = key;
                this.parameters = null;
            }

            private Entry(Parameters parameters) {
                this.keyStatus = KeyStatus.ENABLED;
                this.strategy = null;
                this.builder = null;
                this.key = null;
                this.parameters = parameters;
            }

            @CanIgnoreReturnValue
            public Entry makePrimary() {
                Builder builder = this.builder;
                if (builder != null) {
                    builder.clearPrimary();
                }
                this.isPrimary = true;
                return this;
            }

            public boolean isPrimary() {
                return this.isPrimary;
            }

            @CanIgnoreReturnValue
            public Entry setStatus(KeyStatus keyStatus) {
                this.keyStatus = keyStatus;
                return this;
            }

            public KeyStatus getStatus() {
                return this.keyStatus;
            }

            @CanIgnoreReturnValue
            public Entry withFixedId(int i) {
                this.strategy = KeyIdStrategy.fixedId(i);
                return this;
            }

            @CanIgnoreReturnValue
            public Entry withRandomId() {
                this.strategy = KeyIdStrategy.randomId();
                return this;
            }
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void clearPrimary() {
            Iterator<Entry> it = this.entries.iterator();
            while (it.hasNext()) {
                it.next().isPrimary = false;
            }
        }

        @CanIgnoreReturnValue
        public Builder addEntry(Entry entry) {
            if (entry.builder == null) {
                if (entry.isPrimary) {
                    clearPrimary();
                }
                entry.builder = this;
                this.entries.add(entry);
                return this;
            }
            throw new IllegalStateException("Entry has already been added to a KeysetHandle.Builder");
        }

        @CanIgnoreReturnValue
        @Alpha
        public Builder setMonitoringAnnotations(MonitoringAnnotations monitoringAnnotations) {
            this.annotations = monitoringAnnotations;
            return this;
        }

        public int size() {
            return this.entries.size();
        }

        public Entry getAt(int i) {
            return this.entries.get(i);
        }

        @CanIgnoreReturnValue
        @Deprecated
        public Entry removeAt(int i) {
            return this.entries.remove(i);
        }

        @CanIgnoreReturnValue
        public Builder deleteAt(int i) {
            this.entries.remove(i);
            return this;
        }

        private static void checkIdAssignments(List<Entry> list) throws GeneralSecurityException {
            for (int i = 0; i < list.size() - 1; i++) {
                if (list.get(i).strategy == KeyIdStrategy.RANDOM_ID && list.get(i + 1).strategy != KeyIdStrategy.RANDOM_ID) {
                    throw new GeneralSecurityException("Entries with 'withRandomId()' may only be followed by other entries with 'withRandomId()'.");
                }
            }
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void setErrorToThrow(GeneralSecurityException generalSecurityException) {
            this.errorToThrow = generalSecurityException;
        }

        private static int randomIdNotInSet(Set<Integer> set) {
            int iRandKeyId = 0;
            while (true) {
                if (iRandKeyId != 0 && !set.contains(Integer.valueOf(iRandKeyId))) {
                    return iRandKeyId;
                }
                iRandKeyId = com.google.crypto.tink.internal.Util.randKeyId();
            }
        }

        private static int getNextIdFromBuilderEntry(Entry entry, Set<Integer> set) throws GeneralSecurityException {
            if (entry.strategy != null) {
                if (entry.strategy != KeyIdStrategy.RANDOM_ID) {
                    return entry.strategy.getFixedId();
                }
                return randomIdNotInSet(set);
            }
            throw new GeneralSecurityException("No ID was set (with withFixedId or withRandomId)");
        }

        public KeysetHandle build() throws GeneralSecurityException {
            Entry entry;
            Keyset.Key keyCreateKeysetKey;
            if (this.errorToThrow != null) {
                throw new GeneralSecurityException("Cannot build keyset due to error in original", this.errorToThrow);
            }
            if (this.buildCalled) {
                throw new GeneralSecurityException("KeysetHandle.Builder#build must only be called once");
            }
            this.buildCalled = true;
            Keyset.Builder builderNewBuilder = Keyset.newBuilder();
            ArrayList arrayList = new ArrayList(this.entries.size());
            checkIdAssignments(this.entries);
            HashSet hashSet = new HashSet();
            AnonymousClass1 anonymousClass1 = null;
            Integer numValueOf = null;
            for (Entry entry2 : this.entries) {
                if (entry2.keyStatus == null) {
                    throw new GeneralSecurityException("Key Status not set.");
                }
                int nextIdFromBuilderEntry = getNextIdFromBuilderEntry(entry2, hashSet);
                if (hashSet.contains(Integer.valueOf(nextIdFromBuilderEntry))) {
                    throw new GeneralSecurityException("Id " + nextIdFromBuilderEntry + " is used twice in the keyset");
                }
                hashSet.add(Integer.valueOf(nextIdFromBuilderEntry));
                if (entry2.key == null) {
                    Key keyCreateKey = MutableKeyCreationRegistry.globalInstance().createKey(entry2.parameters, entry2.parameters.hasIdRequirement() ? Integer.valueOf(nextIdFromBuilderEntry) : null);
                    entry = new Entry(keyCreateKey, entry2.keyStatus, nextIdFromBuilderEntry, entry2.isPrimary, null);
                    keyCreateKeysetKey = KeysetHandle.createKeysetKey(keyCreateKey, entry2.keyStatus, nextIdFromBuilderEntry);
                } else {
                    entry = new Entry(entry2.key, entry2.keyStatus, nextIdFromBuilderEntry, entry2.isPrimary, null);
                    keyCreateKeysetKey = KeysetHandle.createKeysetKey(entry2.key, entry2.keyStatus, nextIdFromBuilderEntry);
                }
                builderNewBuilder.addKey(keyCreateKeysetKey);
                if (entry2.isPrimary) {
                    if (numValueOf != null) {
                        throw new GeneralSecurityException("Two primaries were set");
                    }
                    numValueOf = Integer.valueOf(nextIdFromBuilderEntry);
                    if (entry2.keyStatus != KeyStatus.ENABLED) {
                        throw new GeneralSecurityException("Primary key is not enabled");
                    }
                }
                arrayList.add(entry);
            }
            if (numValueOf == null) {
                throw new GeneralSecurityException("No primary was set");
            }
            builderNewBuilder.setPrimaryKeyId(numValueOf.intValue());
            Keyset keysetBuild = builderNewBuilder.build();
            KeysetHandle.assertEnoughKeyMaterial(keysetBuild);
            return new KeysetHandle(keysetBuild, arrayList, this.annotations, anonymousClass1);
        }
    }

    @Immutable
    public static final class Entry implements KeysetHandleInterface.Entry {
        private final int id;
        private final boolean isPrimary;
        private final Key key;
        private final KeyStatus keyStatus;

        /* synthetic */ Entry(Key key, KeyStatus keyStatus, int i, boolean z, AnonymousClass1 anonymousClass1) {
            this(key, keyStatus, i, z);
        }

        private Entry(Key key, KeyStatus keyStatus, int i, boolean z) {
            this.key = key;
            this.keyStatus = keyStatus;
            this.id = i;
            this.isPrimary = z;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public Key getKey() {
            return this.key;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public KeyStatus getStatus() {
            return this.keyStatus;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public int getId() {
            return this.id;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public boolean isPrimary() {
            return this.isPrimary;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public boolean equalsEntry(Entry entry) {
            return entry.isPrimary == this.isPrimary && entry.keyStatus.equals(this.keyStatus) && entry.id == this.id && entry.key.equalsKey(this.key);
        }
    }

    /* JADX INFO: renamed from: com.google.crypto.tink.KeysetHandle$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$com$google$crypto$tink$proto$KeyStatusType;

        static {
            int[] iArr = new int[KeyStatusType.values().length];
            $SwitchMap$com$google$crypto$tink$proto$KeyStatusType = iArr;
            try {
                iArr[KeyStatusType.ENABLED.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$com$google$crypto$tink$proto$KeyStatusType[KeyStatusType.DISABLED.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$com$google$crypto$tink$proto$KeyStatusType[KeyStatusType.DESTROYED.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
        }
    }

    private static KeyStatus parseStatus(KeyStatusType keyStatusType) throws GeneralSecurityException {
        int i = AnonymousClass1.$SwitchMap$com$google$crypto$tink$proto$KeyStatusType[keyStatusType.ordinal()];
        if (i == 1) {
            return KeyStatus.ENABLED;
        }
        if (i == 2) {
            return KeyStatus.DISABLED;
        }
        if (i == 3) {
            return KeyStatus.DESTROYED;
        }
        throw new GeneralSecurityException("Unknown key status");
    }

    private static KeyStatusType serializeStatus(KeyStatus keyStatus) {
        if (KeyStatus.ENABLED.equals(keyStatus)) {
            return KeyStatusType.ENABLED;
        }
        if (KeyStatus.DISABLED.equals(keyStatus)) {
            return KeyStatusType.DISABLED;
        }
        if (KeyStatus.DESTROYED.equals(keyStatus)) {
            return KeyStatusType.DESTROYED;
        }
        throw new IllegalStateException("Unknown key status");
    }

    private static List<Entry> getEntriesFromKeyset(Keyset keyset) {
        ArrayList arrayList = new ArrayList(keyset.getKeyCount());
        for (Keyset.Key key : keyset.getKeyList()) {
            int keyId = key.getKeyId();
            try {
                arrayList.add(new Entry(toKey(key), parseStatus(key.getStatus()), keyId, keyId == keyset.getPrimaryKeyId(), null));
            } catch (GeneralSecurityException unused) {
                arrayList.add(null);
            }
        }
        return Collections.unmodifiableList(arrayList);
    }

    private Entry entryByIndex(int i) {
        if (this.entries.get(i) == null) {
            throw new IllegalStateException("Keyset-Entry at position " + i + " has wrong status or key parsing failed");
        }
        return this.entries.get(i);
    }

    public static Builder.Entry importKey(Key key) {
        Builder.Entry entry = new Builder.Entry(key, (AnonymousClass1) null);
        Integer idRequirementOrNull = key.getIdRequirementOrNull();
        if (idRequirementOrNull != null) {
            entry.withFixedId(idRequirementOrNull.intValue());
        }
        return entry;
    }

    public static Builder.Entry generateEntryFromParametersName(String str) {
        return new Builder.Entry(MutableParametersRegistry.globalInstance().get(str), (AnonymousClass1) null);
    }

    public static Builder.Entry generateEntryFromParameters(Parameters parameters) {
        return new Builder.Entry(parameters, (AnonymousClass1) null);
    }

    private KeysetHandle(Keyset keyset, List<Entry> list) {
        this.keyset = keyset;
        this.entries = list;
        this.annotations = MonitoringAnnotations.EMPTY;
    }

    private KeysetHandle(Keyset keyset, List<Entry> list, MonitoringAnnotations monitoringAnnotations) {
        this.keyset = keyset;
        this.entries = list;
        this.annotations = monitoringAnnotations;
    }

    static final KeysetHandle fromKeyset(Keyset keyset) throws GeneralSecurityException {
        assertEnoughKeyMaterial(keyset);
        return new KeysetHandle(keyset, getEntriesFromKeyset(keyset));
    }

    static final KeysetHandle fromKeysetAndAnnotations(Keyset keyset, MonitoringAnnotations monitoringAnnotations) throws GeneralSecurityException {
        assertEnoughKeyMaterial(keyset);
        return new KeysetHandle(keyset, getEntriesFromKeyset(keyset), monitoringAnnotations);
    }

    Keyset getKeyset() {
        return this.keyset;
    }

    public static Builder newBuilder() {
        return new Builder();
    }

    public static Builder newBuilder(KeysetHandle keysetHandle) {
        Builder builder = new Builder();
        for (int i = 0; i < keysetHandle.size(); i++) {
            Entry entry = keysetHandle.entries.get(i);
            if (entry == null) {
                builder.setErrorToThrow(new GeneralSecurityException("Keyset-Entry in original keyset at position " + i + " has wrong status or key parsing failed"));
                return builder;
            }
            Builder.Entry entryWithFixedId = importKey(entry.getKey()).withFixedId(entry.getId());
            entryWithFixedId.setStatus(entry.getStatus());
            if (entry.isPrimary()) {
                entryWithFixedId.makePrimary();
            }
            builder.addEntry(entryWithFixedId);
        }
        return builder;
    }

    @Override // com.google.crypto.tink.internal.KeysetHandleInterface
    public Entry getPrimary() {
        for (Entry entry : this.entries) {
            if (entry != null && entry.isPrimary()) {
                if (entry.getStatus() == KeyStatus.ENABLED) {
                    return entry;
                }
                throw new IllegalStateException("Keyset has primary which isn't enabled");
            }
        }
        throw new IllegalStateException("Keyset has no valid primary");
    }

    @Override // com.google.crypto.tink.internal.KeysetHandleInterface
    public int size() {
        return this.entries.size();
    }

    @Override // com.google.crypto.tink.internal.KeysetHandleInterface
    public Entry getAt(int i) {
        if (i < 0 || i >= size()) {
            throw new IndexOutOfBoundsException("Invalid index " + i + " for keyset of size " + size());
        }
        return entryByIndex(i);
    }

    @Deprecated
    public List<KeyHandle> getKeys() {
        ArrayList arrayList = new ArrayList();
        for (Keyset.Key key : this.keyset.getKeyList()) {
            arrayList.add(new InternalKeyHandle(new ProtoKey(key.getKeyData(), KeyTemplate.fromProto(key.getOutputPrefixType())), key.getStatus(), key.getKeyId()));
        }
        return Collections.unmodifiableList(arrayList);
    }

    @Deprecated
    public KeysetInfo getKeysetInfo() {
        return Util.getKeysetInfo(this.keyset);
    }

    public static final KeysetHandle generateNew(Parameters parameters) {
        return newBuilder().addEntry(generateEntryFromParameters(parameters).withRandomId().makePrimary()).build();
    }

    @Deprecated
    public static final KeysetHandle generateNew(com.google.crypto.tink.proto.KeyTemplate keyTemplate) {
        return generateNew(TinkProtoParametersFormat.parse(keyTemplate.toByteArray()));
    }

    public static final KeysetHandle generateNew(KeyTemplate keyTemplate) {
        return generateNew(keyTemplate.toParameters());
    }

    @Deprecated
    public static final KeysetHandle createFromKey(KeyHandle keyHandle, KeyAccess keyAccess) {
        KeysetManager keysetManagerAdd = KeysetManager.withEmptyKeyset().add(keyHandle);
        keysetManagerAdd.setPrimary(keysetManagerAdd.getKeysetHandle().getKeysetInfo().getKeyInfo(0).getKeyId());
        return keysetManagerAdd.getKeysetHandle();
    }

    @Deprecated
    public static final KeysetHandle read(KeysetReader keysetReader, Aead aead) {
        return readWithAssociatedData(keysetReader, aead, new byte[0]);
    }

    @Deprecated
    public static final KeysetHandle readWithAssociatedData(KeysetReader keysetReader, Aead aead, byte[] bArr) throws GeneralSecurityException {
        EncryptedKeyset encrypted = keysetReader.readEncrypted();
        assertEnoughEncryptedKeyMaterial(encrypted);
        return fromKeyset(decrypt(encrypted, aead, bArr));
    }

    @Deprecated
    public static final KeysetHandle readNoSecret(KeysetReader keysetReader) throws GeneralSecurityException {
        try {
            return readNoSecret(keysetReader.read().toByteArray());
        } catch (InvalidProtocolBufferException unused) {
            throw new GeneralSecurityException("invalid keyset");
        }
    }

    @Deprecated
    public static final KeysetHandle readNoSecret(byte[] bArr) throws GeneralSecurityException {
        try {
            Keyset from = Keyset.parseFrom(bArr, ExtensionRegistryLite.getEmptyRegistry());
            assertNoSecretKeyMaterial(from);
            return fromKeyset(from);
        } catch (InvalidProtocolBufferException unused) {
            throw new GeneralSecurityException("invalid keyset");
        }
    }

    @Deprecated
    public void write(KeysetWriter keysetWriter, Aead aead) {
        writeWithAssociatedData(keysetWriter, aead, new byte[0]);
    }

    @Deprecated
    public void writeWithAssociatedData(KeysetWriter keysetWriter, Aead aead, byte[] bArr) {
        keysetWriter.write(encrypt(this.keyset, aead, bArr));
    }

    @Deprecated
    public void writeNoSecret(KeysetWriter keysetWriter) throws GeneralSecurityException {
        assertNoSecretKeyMaterial(this.keyset);
        keysetWriter.write(this.keyset);
    }

    private static EncryptedKeyset encrypt(Keyset keyset, Aead aead, byte[] bArr) {
        return EncryptedKeyset.newBuilder().setEncryptedKeyset(ByteString.copyFrom(aead.encrypt(keyset.toByteArray(), bArr))).setKeysetInfo(Util.getKeysetInfo(keyset)).build();
    }

    private static Keyset decrypt(EncryptedKeyset encryptedKeyset, Aead aead, byte[] bArr) throws GeneralSecurityException {
        try {
            Keyset from = Keyset.parseFrom(aead.decrypt(encryptedKeyset.getEncryptedKeyset().toByteArray(), bArr), ExtensionRegistryLite.getEmptyRegistry());
            assertEnoughKeyMaterial(from);
            return from;
        } catch (InvalidProtocolBufferException unused) {
            throw new GeneralSecurityException("invalid keyset, corrupted key material");
        }
    }

    public KeysetHandle getPublicKeysetHandle() throws GeneralSecurityException {
        Keyset.Key keyBuild;
        Entry entry;
        if (this.keyset == null) {
            throw new GeneralSecurityException("cleartext keyset is not available");
        }
        Keyset.Builder builderNewBuilder = Keyset.newBuilder();
        ArrayList arrayList = new ArrayList(this.entries.size());
        int i = 0;
        for (Entry entry2 : this.entries) {
            if (entry2 != null && (entry2.getKey() instanceof PrivateKey)) {
                Key publicKey = ((PrivateKey) entry2.getKey()).getPublicKey();
                entry = new Entry(publicKey, entry2.getStatus(), entry2.getId(), entry2.isPrimary(), null);
                keyBuild = createKeysetKey(publicKey, entry2.getStatus(), entry2.getId());
            } else {
                Keyset.Key key = this.keyset.getKey(i);
                keyBuild = key.toBuilder().setKeyData(getPublicKeyDataFromRegistry(key.getKeyData())).build();
                try {
                    Key key2 = toKey(keyBuild);
                    int keyId = keyBuild.getKeyId();
                    entry = new Entry(key2, parseStatus(keyBuild.getStatus()), keyId, keyId == this.keyset.getPrimaryKeyId(), null);
                } catch (GeneralSecurityException unused) {
                    entry = null;
                }
            }
            builderNewBuilder.addKey(keyBuild);
            arrayList.add(entry);
            i++;
        }
        builderNewBuilder.setPrimaryKeyId(this.keyset.getPrimaryKeyId());
        return new KeysetHandle(builderNewBuilder.build(), arrayList, this.annotations);
    }

    private static KeyData getPublicKeyDataFromRegistry(KeyData keyData) throws GeneralSecurityException {
        if (keyData.getKeyMaterialType() != KeyData.KeyMaterialType.ASYMMETRIC_PRIVATE) {
            throw new GeneralSecurityException("The keyset contains a non-private key");
        }
        return Registry.getPublicKeyData(keyData.getTypeUrl(), keyData.getValue());
    }

    public String toString() {
        return getKeysetInfo().toString();
    }

    private static void assertNoSecretKeyMaterial(Keyset keyset) throws GeneralSecurityException {
        for (Keyset.Key key : keyset.getKeyList()) {
            if (key.getKeyData().getKeyMaterialType() == KeyData.KeyMaterialType.UNKNOWN_KEYMATERIAL || key.getKeyData().getKeyMaterialType() == KeyData.KeyMaterialType.SYMMETRIC || key.getKeyData().getKeyMaterialType() == KeyData.KeyMaterialType.ASYMMETRIC_PRIVATE) {
                throw new GeneralSecurityException(String.format("keyset contains key material of type %s for type url %s", key.getKeyData().getKeyMaterialType().name(), key.getKeyData().getTypeUrl()));
            }
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static void assertEnoughKeyMaterial(Keyset keyset) throws GeneralSecurityException {
        if (keyset == null || keyset.getKeyCount() <= 0) {
            throw new GeneralSecurityException("empty keyset");
        }
    }

    private static void assertEnoughEncryptedKeyMaterial(EncryptedKeyset encryptedKeyset) throws GeneralSecurityException {
        if (encryptedKeyset == null || encryptedKeyset.getEncryptedKeyset().size() == 0) {
            throw new GeneralSecurityException("empty keyset");
        }
    }

    private <B, P> P getPrimitiveWithKnownInputPrimitive(final InternalConfiguration internalConfiguration, Class<P> cls, final Class<B> cls2) throws GeneralSecurityException {
        Util.validateKeyset(this.keyset);
        PrimitiveSet.Builder builderNewBuilder = PrimitiveSet.newBuilder(cls2);
        builderNewBuilder.setAnnotations(this.annotations);
        for (int i = 0; i < size(); i++) {
            Keyset.Key key = this.keyset.getKey(i);
            if (key.getStatus().equals(KeyStatusType.ENABLED)) {
                Entry entry = this.entries.get(i);
                if (entry == null) {
                    throw new GeneralSecurityException("Key parsing of key with index " + i + " and type_url " + key.getKeyData().getTypeUrl() + " failed, unable to get primitive");
                }
                Key key2 = entry.getKey();
                if (key.getKeyId() == this.keyset.getPrimaryKeyId()) {
                    builderNewBuilder.addPrimary(key2, key);
                } else {
                    builderNewBuilder.add(key2, key);
                }
            }
        }
        builderNewBuilder.addPrimitiveConstructor(new PrimitiveConstructor.PrimitiveConstructionFunction() { // from class: com.google.crypto.tink.KeysetHandle$$ExternalSyntheticLambda0
            @Override // com.google.crypto.tink.internal.PrimitiveConstructor.PrimitiveConstructionFunction
            public final Object constructPrimitive(Key key3) {
                return internalConfiguration.getPrimitive(key3, cls2);
            }
        });
        return (P) internalConfiguration.wrap(builderNewBuilder.build(), cls);
    }

    public <P> P getPrimitive(Configuration configuration, Class<P> cls) throws GeneralSecurityException {
        if (!(configuration instanceof InternalConfiguration)) {
            throw new GeneralSecurityException("Currently only subclasses of InternalConfiguration are accepted");
        }
        InternalConfiguration internalConfiguration = (InternalConfiguration) configuration;
        Class<?> inputPrimitiveClass = internalConfiguration.getInputPrimitiveClass(cls);
        if (inputPrimitiveClass == null) {
            throw new GeneralSecurityException("No wrapper found for " + cls.getName());
        }
        return (P) getPrimitiveWithKnownInputPrimitive(internalConfiguration, cls, inputPrimitiveClass);
    }

    @InlineMe(imports = {"com.google.crypto.tink.RegistryConfiguration"}, replacement = "this.getPrimitive(RegistryConfiguration.get(), targetClassObject)")
    @Deprecated
    public <P> P getPrimitive(Class<P> cls) {
        return (P) getPrimitive(RegistryConfiguration.get(), cls);
    }

    @Deprecated
    public KeyHandle primaryKey() throws GeneralSecurityException {
        int primaryKeyId = this.keyset.getPrimaryKeyId();
        for (Keyset.Key key : this.keyset.getKeyList()) {
            if (key.getKeyId() == primaryKeyId) {
                return new InternalKeyHandle(new ProtoKey(key.getKeyData(), KeyTemplate.fromProto(key.getOutputPrefixType())), key.getStatus(), key.getKeyId());
            }
        }
        throw new GeneralSecurityException("No primary key found in keyset.");
    }

    public boolean equalsKeyset(KeysetHandle keysetHandle) {
        if (size() != keysetHandle.size()) {
            return false;
        }
        boolean z = false;
        for (int i = 0; i < size(); i++) {
            Entry entry = this.entries.get(i);
            Entry entry2 = keysetHandle.entries.get(i);
            if (entry == null || entry2 == null || !entry.equalsEntry(entry2)) {
                return false;
            }
            z |= entry.isPrimary;
        }
        return z;
    }

    private static ProtoKeySerialization toProtoKeySerialization(Keyset.Key key) {
        return ProtoKeySerialization.create(key.getKeyData().getTypeUrl(), key.getKeyData().getValue(), key.getKeyData().getKeyMaterialType(), key.getOutputPrefixType(), key.getOutputPrefixType() == OutputPrefixType.RAW ? null : Integer.valueOf(key.getKeyId()));
    }

    private static Key toKey(Keyset.Key key) {
        return MutableSerializationRegistry.globalInstance().parseKeyWithLegacyFallback(toProtoKeySerialization(key), InsecureSecretKeyAccess.get());
    }

    private static Keyset.Key toKeysetKey(int i, KeyStatusType keyStatusType, ProtoKeySerialization protoKeySerialization) {
        return Keyset.Key.newBuilder().setKeyData(KeyData.newBuilder().setTypeUrl(protoKeySerialization.getTypeUrl()).setValue(protoKeySerialization.getValue()).setKeyMaterialType(protoKeySerialization.getKeyMaterialType())).setStatus(keyStatusType).setKeyId(i).setOutputPrefixType(protoKeySerialization.getOutputPrefixType()).build();
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static Keyset.Key createKeysetKey(Key key, KeyStatus keyStatus, int i) throws GeneralSecurityException {
        ProtoKeySerialization protoKeySerialization = (ProtoKeySerialization) MutableSerializationRegistry.globalInstance().serializeKey(key, ProtoKeySerialization.class, InsecureSecretKeyAccess.get());
        Integer idRequirementOrNull = protoKeySerialization.getIdRequirementOrNull();
        if (idRequirementOrNull != null && idRequirementOrNull.intValue() != i) {
            throw new GeneralSecurityException("Wrong ID set for key with ID requirement");
        }
        return toKeysetKey(i, serializeStatus(keyStatus), protoKeySerialization);
    }
}
