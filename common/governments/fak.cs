caliphate_government = {

	primary_holding = castle_holding
	primary_heritages = { heritage_arabic heritage_iranian heritage_turkic }
	preferred_religions = { islam_religion }
	create_cadet_branches = yes
	rulers_should_have_dynasty = yes
	royal_court = yes

	valid_holdings = { castle_holding }
	required_county_holdings = { castle_holding city_holding church_holding }

	always_use_patronym = yes
	dynasty_named_realms = yes

	vassal_contract = {
		clan_government_obligations special_contract
		religious_rights war_declaration_rights
		council_rights title_revocation_rights
		jizya_special_rights iqta_special_rights
		ghazi_special_rights marriage_favor_rights
	}

	character_modifier = {
		monthly_dynasty_prestige_mult = 3
		monthly_prestige_gain_mult = 1.4
		monthly_prestige_gain_per_dread_mult = 0.2
		monthly_income_mult = 1.5
		monthly_war_income_mult = -1
		monthly_war_income_add = -17
		dynasty_opinion = 20
		army_maintenance_mult = -0.6
		mercenary_hire_cost_mult = 0.5
		holy_order_hire_cost_mult = 0.5
		opinion_of_female_rulers = -40
		opinion_of_different_faith = -20
		opinion_of_parents = 30
		close_relative_opinion = -20
		tax_mult = 1
		fort_level = 1
		levy_size = -10
		men_at_arms_limit = 2
		tyranny_gain_mult = 2
	}

	opinion_of_liege = {
	scope:vassal = {
			if = {
				limit = {
					NOT =
					{
						is_allied_to = scope:liege
					}
				}
				if = {
					limit = {
						is_powerful_vassal = yes

					}
					value = -30
				}
				else = {
					value = -15
				}
			}
		}
	}
	opinion_of_liege_desc = {
		first_valid = {
			triggered_desc = {
				trigger = {
				scope:vassal = {
						NOT = {
							is_allied_to = scope:liege
						}
						is_powerful_vassal = yes
					}
				}
				desc = "GOVERNMENT_CLAN_NOT_ALLIED_POWERFUL"
			}
			triggered_desc = {
				trigger = {
				scope:vassal = {
						NOT = {
							is_allied_to = scope:liege
						}
						is_powerful_vassal = no
					}
				}
				desc = "GOVERNMENT_CLAN_NOT_ALLIED"
			}
		}
	}

	flag = government_can_raid_rule
	flag = government_is_caliphate

	color = hsv { 0.39 0.93 0.54 }
}

autocracy_government = {
	create_cadet_branches = yes
    rulers_should_have_dynasty = yes
    dynasty_named_realms = yes

    royal_court = yes
    primary_holding = castle_holding

    required_county_holdings = { castle_holding city_holding church_holding  }

    character_modifier = {
		monthly_prestige_gain_mult = 0.4
        monthly_prestige_gain_per_dread_mult = -0.4
        monthly_prestige_from_buildings_mult = 0.5
        monthly_prestige_gain_per_knight_mult = 0.2
        monthly_lifestyle_xp_gain_mult = 0.1
        army_maintenance_mult = 0.5
        dread_per_tyranny_mult = 0.1
        tyranny_gain_mult = 5
        domain_limit = 99
        development_growth_factor = 0.2
        domain_tax_mult = 0.5
        scheme_power = 0.2
        scheme_secrecy = 0.1
        stress_gain_mult = 0.01
    }

	vassal_contract = {
		feudal_government_taxes feudal_government_levies
		special_contract religious_rights
		fortification_rights coinage_rights
		succession_rights war_declaration_rights
		council_rights title_revocation_rights
	}

	flag = government_is_autocracy
    flag = government_can_raid_rule
    color = hsv { 0.00 0.01 0.01 }
}

citystate_government = {
	
	rulers_should_have_dynasty = yes
    royal_court = yes

    primary_holding = city_holding
	valid_holdings = { castle_holding tribal_holding church_holding}
	required_county_holdings = { city_holding castle_holding }

	vassal_contract = { 
		feudal_government_taxes
		feudal_government_levies
		religious_rights
		fortification_rights
		coinage_rights
		succession_rights
		war_declaration_rights
		council_rights
		title_revocation_rights 
	}

	character_modifier = {
		domain_limit = -200
		short_reign_duration_mult = -0.25
		long_reign_bonus_mult = 0.25
		monthly_income_mult = 0.1
		development_growth_factor = 0.5
		diplomatic_range_mult = 0.5
		army_maintenance_mult = -0.1
		controlled_province_advantage = 0.1
	}

	opinion_of_liege = {
		scope:vassal = {
			if = {
				limit = {
					scope:liege = {
                        flag = government_is_citystate
                    }
				}
				if = {
					limit = {
						scope:liege = {
							var:ecostability.compare_value > 50
						}
					}
						if = {
							limit = {
								scope:liege = {
									var:ecostability.compare_value > 100
								}
							}
							value = 20
						}
						else_if = {
							limit = {
								scope:liege = {
									var:ecostability.compare_value < 100
								}
							}
							value = 10
						}
				}
				else_if = {
					limit = {
						scope:liege = {
							var:ecostability.compare_value < -50
						}
					}
						if = {
							limit = {
								scope:liege = {
									var:ecostability.compare_value > -100
								}
							}
							value = -10
						}
						else_if = {
							limit = {
								scope:liege = {
									var:ecostability.compare_value < -100
								}
							}
							value = -20
						}
				}
				
			}
		}
	}

	opinion_of_liege_desc = {
		first_valid = {
			desc = tfe_economic_stability
		}
	}

    flag = government_is_citystate
	flag = government_can_raid_rule	
    color = hsv{ 1.0 0.0 1.0 }
}