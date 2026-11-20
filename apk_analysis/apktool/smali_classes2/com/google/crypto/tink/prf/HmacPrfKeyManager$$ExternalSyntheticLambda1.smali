.class public final synthetic Lcom/google/crypto/tink/prf/HmacPrfKeyManager$$ExternalSyntheticLambda1;
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
    check-cast p1, Lcom/google/crypto/tink/prf/HmacPrfParameters;

    invoke-static {p1, p2}, Lcom/google/crypto/tink/prf/HmacPrfKeyManager;->$r8$lambda$WL0qqcn7MRS14Wpc_hPjuE0-VmY(Lcom/google/crypto/tink/prf/HmacPrfParameters;Ljava/lang/Integer;)Lcom/google/crypto/tink/prf/HmacPrfKey;

    move-result-object p1

    return-object p1
.end method
