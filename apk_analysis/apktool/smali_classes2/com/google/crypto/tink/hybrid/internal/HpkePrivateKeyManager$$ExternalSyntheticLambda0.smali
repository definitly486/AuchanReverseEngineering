.class public final synthetic Lcom/google/crypto/tink/hybrid/internal/HpkePrivateKeyManager$$ExternalSyntheticLambda0;
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
    check-cast p1, Lcom/google/crypto/tink/hybrid/HpkeParameters;

    invoke-static {p1, p2}, Lcom/google/crypto/tink/hybrid/internal/HpkePrivateKeyManager;->$r8$lambda$1C08Z3qY2egLImizMJ5L3IdIajg(Lcom/google/crypto/tink/hybrid/HpkeParameters;Ljava/lang/Integer;)Lcom/google/crypto/tink/hybrid/HpkePrivateKey;

    move-result-object p1

    return-object p1
.end method
