.class public final synthetic Lcom/google/crypto/tink/aead/KmsAeadKeyManager$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Lcom/google/crypto/tink/internal/MutableKeyCreationRegistry$KeyCreator;


# direct methods
.method public synthetic constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public final createKey(Lcom/google/crypto/tink/Parameters;Ljava/lang/Integer;)Lcom/google/crypto/tink/Key;
    .locals 0

    .line 0
    check-cast p1, Lcom/google/crypto/tink/aead/LegacyKmsAeadParameters;

    invoke-static {p1, p2}, Lcom/google/crypto/tink/aead/KmsAeadKeyManager;->$r8$lambda$WH4khbgnnZQJk28kC95gjFGFisY(Lcom/google/crypto/tink/aead/LegacyKmsAeadParameters;Ljava/lang/Integer;)Lcom/google/crypto/tink/aead/LegacyKmsAeadKey;

    move-result-object p1

    return-object p1
.end method
